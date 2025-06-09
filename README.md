# IdentityServer
Identity server in c#
<p>IdentityServer is an OpenID Connect and OAuth 2.0 framework for ASP.NET Core that provides authentication and authorization capabilities. It's commonly used to build secure, centralized login solutions for modern applications.</p>

<h2>What is IdentityServer?</h2>
<p>IdentityServer acts as a security token service (STS). It issues security tokens (like JWTs) to clients after users are authenticated, allowing other apps and APIs to trust those tokens and avoid handling user authentication themselves.</p>

<h2>🧰 Key Features</h2>
<ol>
  <li>
    Authentication : Users log in using IdentityServer, which verifies credentials and returns a token.
  </li>
  <li>
    Single Sign-On (SSO) : Once logged in, users can access multiple applications without logging in again.
  </li>
  <li>
    Token Issuance : Issues access tokens and ID tokens following OAuth 2.0 and OpenID Connect standards.
  </li>
  <li>
    API Authorization : Protects APIs by validating tokens and scopes.
  </li>
  <li>
    Federation Gateway : Can act as a bridge to other identity providers like Google, Microsoft, or Active Directory.
  </li>
</ol>

✅ What Does "Token Issuance" Mean?
Token issuance refers to the process where IdentityServer generates tokens after a successful authentication or authorization request from a client (like a web or mobile app).

There are mainly two types of tokens issued:
🔑 1. Access Token (OAuth 2.0) : (Basically used to API call)
This token grants access to protected APIs (also called resource servers).
It’s usually a JWT or reference token.
Clients send this token in the Authorization header when making API calls.

🧠 OAuth 2.0 defines the rules and flows (like client credentials, password grant, etc.) under which these tokens are issued and validated.

🆔 2. ID Token (OpenID Connect)
ID token is a JWT specifically designed to carry identity information about the user (like name, email, etc.).
It is not used to access APIs, but rather to prove the user's identity to the client (such as in a login flow).

🧠 OpenID Connect (OIDC) is a protocol built on top of OAuth 2.0 that introduces id_token and defines how authentication works.

✅ Example Flow (Authorization Code + PKCE):
User logs in from your frontend app.
IdentityServer authenticates the user.
IdentityServer returns:
id_token to the frontend (user identity)
access_token for calling APIs
The frontend stores the tokens securely and uses them appropriately.

OpenID Connect (OIDC) is a protocol built on top of OAuth 2.0 that introduces id_token and defines how authentication works.

✅ 1. OAuth 2.0: Authorization Only
OAuth 2.0 is a delegated authorization protocol. It allows applications (clients) to access resources on behalf of a user.

But it does NOT provide any way to:
Authenticate the user
Know who the user is
Share user profile data
🧠 Example use case:
A third-party app wants to access your Google Drive files without knowing who you are—just that you’ve authorized it.

🧾 2. OpenID Connect (OIDC): Adds Authentication Layer
OIDC builds on top of OAuth 2.0 and adds authentication.

It answers:
✅ Who is the user?
✅ Is the user really authenticated?
✅ What is the user’s email, name, etc.?
OIDC introduces a new token called the id_token.

This token is:
A JWT (JSON Web Token)
Issued after successful authentication
Contains identity claims about the user (like sub, name, email, etc.)

🔐 3. How It Works Together
Let’s compare OAuth 2.0 and OpenID Connect through an example:

Feature	OAuth 2.0	OpenID Connect
Purpose	Authorization	Authentication + Authorization
Main Token	access_token	id_token (plus access_token)
Identifies User	❌ No	✅ Yes
Returns Profile Info	❌ No	✅ Yes (via UserInfo endpoint)

✅ Conclusion
If your app just needs to call an API, only access_token is needed.
If your app needs to know who is logged in, id_token is used.
Both tokens are commonly issued together, but not both are required for API calls.

![image](https://github.com/user-attachments/assets/8ebcc38d-e0ec-4a86-861d-8e668020ba0d)

