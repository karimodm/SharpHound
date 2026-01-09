using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Logging;

namespace Sharphound.Runtime
{
    internal static class ZipEncryptor
    {
        internal static string EncryptZip(string zipPath, ILogger logger)
        {
            if (string.IsNullOrWhiteSpace(zipPath) || !File.Exists(zipPath))
                return zipPath;

            if (!EncryptionConfig.HasValidPublicCert)
                throw new InvalidOperationException("Public key not configured. Set EncryptionConfig.PublicCertDerBase64.");

            var encryptedPath = zipPath + ".cms";

            try
            {
                var certBytes = Convert.FromBase64String(EncryptionConfig.PublicCertDerBase64);
                var cert = new X509Certificate2(certBytes);

                var data = File.ReadAllBytes(zipPath);
                var contentInfo = new ContentInfo(data);
                var envelopedCms = new EnvelopedCms(contentInfo);
                var recipient = new CmsRecipient(SubjectIdentifierType.IssuerAndSerialNumber, cert);
                envelopedCms.Encrypt(recipient);
                var encoded = envelopedCms.Encode();

                File.WriteAllBytes(encryptedPath, encoded);
                File.Delete(zipPath);
                logger.LogInformation("Encrypted zip written to {Filename}", encryptedPath);

                return encryptedPath;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to encrypt zip file {Filename}", zipPath);
                throw;
            }
        }
    }
}
