using System;

namespace Sharphound.Runtime
{
    internal static class EncryptionConfig
    {
        // Replace with your public certificate in BASE64 DER (no headers, no newlines).
        // Example: openssl x509 -in cert.pem -outform DER | base64 -w0
        internal const string PublicCertDerBase64 = "MIIDCzCCAfOgAwIBAgIUamOOeIIny94BpY2EHdM+O9yMLccwDQYJKoZIhvcNAQELBQAwFTETMBEGA1UEAwwKU2hhcnBIb3VuZDAeFw0yNjAxMDkwODQ5MDRaFw0zNjAxMDcwODQ5MDRaMBUxEzARBgNVBAMMClNoYXJwSG91bmQwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCl09yeL/efju5j0/Es+03AE2uQzx/+FSNZivZV3rg5V2hJl3//zRZpy+dO3NzRzoN+gGAbeuM6g2HKZPBPkqL2pHuZ2v3OSyVCmGpSVxWBGSxclj+OZydjLi8DniPFbBnLqBvfdO5UXPrbeTjVb8Iv8mnp0YHDcj5V7szuwCeMyf8T//perC6iZxOo5tl4ipypJtgPQNpqYI6zSCRPSSB4d2sD6N/bMQKY5CR9a1OWECygOtHHAV2v3BxgvrxklNtcuHMNvR3AI/28BZ49xPFgq7vGqcKcfS9CCBHd6syVt/pg5EVjtpUz4O2pQ7JiS8r/RcxaDteiI3vtBDAj+QbfAgMBAAGjUzBRMB0GA1UdDgQWBBSIcKJOg3ykYHDc5k1sebLPSmrpPzAfBgNVHSMEGDAWgBSIcKJOg3ykYHDc5k1sebLPSmrpPzAPBgNVHRMBAf8EBTADAQH/MA0GCSqGSIb3DQEBCwUAA4IBAQA8eJURNYVfl8CPTi9/pvcCzAOoR2dkCoYViIsTwRKIu894CivKraGvL6JuWLfd/nd5CHegnTM4LoAF4dlb8mPaYoOujx6o/8Tr9AJN2AipGHr9IvzPftqIoOeUjyyjQyArnaR/1t93vaTxAM8yDUowikx7XVdfYLGYcQMsneLxck6AOrWLl7u3ao5dSBy+eVymPEZRnTSipvXFZzYiFlqWdBj/vwE/bIc3k+njcLGupG+/kygfbD5Jcx1GkxbNKXMPltCIxOacZemVd3Y3uENcnRyzvlvcqHEDf0zstwKH+Ct0CmU/5UmU3efsyhWxhl/f+6p1tEwhjv4W+AHJpDyf";

        internal static bool HasValidPublicCert =>
            !string.IsNullOrWhiteSpace(PublicCertDerBase64) &&
            !PublicCertDerBase64.StartsWith("REPLACE_", StringComparison.Ordinal);
    }
}
