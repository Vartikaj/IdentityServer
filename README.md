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






