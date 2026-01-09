# SharpHound Zip Encryption

This build encrypts the final `.zip` into a CMS (`.cms`) file using your RSA public cert.
Only the encrypted file is left on disk; the plaintext `.zip` is deleted.

## Generate RSA key + cert (Linux)
```bash
openssl genrsa -out key.pem 2048
openssl req -new -x509 -key key.pem -out cert.pem -days 3650 -subj "/CN=SharpHound"
```

## Put the public cert in code
```bash
openssl x509 -in cert.pem -outform DER | base64 -w0
```
Paste the output into `src/Runtime/EncryptionConfig.cs`:
```csharp
internal const string PublicCertDerBase64 = "PASTE_BASE64_DER_HERE";
```

## Decrypt on Linux
```bash
openssl cms -decrypt -inform DER -in output.zip.cms -inkey key.pem -out output.zip
```
