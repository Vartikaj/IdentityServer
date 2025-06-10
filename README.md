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

<h2>✅ What Does "Token Issuance" Mean?</h2>
<p>Token issuance refers to the process where IdentityServer generates tokens after a successful authentication or authorization request from a client (like a web or mobile app).</p>

<h3>There are mainly two types of tokens issued:</h3>
<ol>
  <li>
    🔑 Access Token (OAuth 2.0) : (Basically used to API call)
    <ul>
      <li>This token grants access to protected APIs (also called resource servers).</li>
      <li>It’s usually a JWT or reference token.</li>
      <li>Clients send this token in the Authorization header when making API calls.</li>
    </ul>
    <p>🧠 OAuth 2.0 defines the rules and flows (like client credentials, password grant, etc.) under which these tokens are issued and validated.</p>
  </li>

  <li>
    🆔 ID Token (OpenID Connect)
    <ul>
      <li>ID token is a JWT specifically designed to carry identity information about the user (like name, email, etc.).</li>
      <li>It is not used to access APIs, but rather to prove the user's identity to the client (such as in a login flow).</li>
    </ul>
    <p>🧠 OpenID Connect (OIDC) is a protocol built on top of OAuth 2.0 that introduces id_token and defines how authentication works.</p>
  </li>
</ol>

<h3>✅ Example Flow (Authorization Code + PKCE):</h3>
<ol>
  <li>User logs in from your frontend app.</li>
  <li>IdentityServer authenticates the user.</li>
  <li>IdentityServer returns:
    <ol>
      <li>id_token to the frontend (user identity)</li>
      <li>access_token for calling APIs</li>
      <li>The frontend stores the tokens securely and uses them appropriately.</li>
    </ol>
  </li>
</ol>


<h3>OpenID Connect (OIDC)</h3>
<p>OpenID Connect (OIDC) is a protocol built on top of OAuth 2.0 that introduces id_token and defines how authentication works.</p>

<ol>
  <li>
    <strong>✅ OAuth 2.0: Authorization Only</strong><br>
    OAuth 2.0 is a delegated authorization protocol. It allows applications (clients) to access resources on behalf of a user.<br><br>
    However, it does <strong>not</strong> provide any way to:
    <ul>
      <li>Authenticate the user</li>
      <li>Know who the user is</li>
      <li>Share user profile data</li>
    </ul>
    <p>🧠 <strong>Example use case:</strong><br>
    A third-party app wants to access your Google Drive files without knowing who you are—just that you’ve authorized it.</p>
  </li>
  <li>
    <strong>🧾 OpenID Connect (OIDC): Adds Authentication Layer</strong><br>
    OIDC builds on top of OAuth 2.0 and adds authentication.
    <ol>
      <li>✅ Who is the user?</li>
      <li>✅ Is the user really authenticated?</li>
      <li>✅ What is the user’s email, name, etc.?</li>
    </ol>
    <p>OIDC introduces a new token called the <strong>id_token</strong>.</p>

    <h4>This token is:</h4>
    <ol>
      <li>A JWT (JSON Web Token)</li>
      <li>Issued after successful authentication</li>
      <li>Contains identity claims about the user (like sub, name, email, etc.)</li>
    </ol>
  </li>
  <li>
    <strong>🔐 How It Works Together</strong>
    Let’s compare OAuth 2.0 and OpenID Connect through an example:
    Feature	OAuth 2.0	OpenID Connect
<table border="1" cellpadding="8" cellspacing="0">
  <thead>
    <tr>
      <th>Purpose</th>
      <th>Authorization</th>
      <th>Authentication + Authorization</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Main Token</td>
      <td><code>access_token</code></td>
      <td><code>id_token</code> (plus <code>access_token</code>)</td>
    </tr>
    <tr>
      <td>Identifies User</td>
      <td>❌ No</td>
      <td>✅ Yes</td>
    </tr>
    <tr>
      <td>Returns Profile Info</td>
      <td>❌ No</td>
      <td>✅ Yes (via UserInfo endpoint)</td>
    </tr>
  </tbody>
</table>
  </li>
</ol>
<h3>✅ Conclusion</h3>
<ol>
  <li>If your app just needs to call an API, only <code>access_token</code> is needed.</li>
  <li>If your app needs to know who is logged in, <code>id_token</code> is used.</li>
  <li>Both tokens are commonly issued together, but not both are required for API calls.</li>
</ol>

![image](https://github.com/user-attachments/assets/8ebcc38d-e0ec-4a86-861d-8e668020ba0d)

<h3>✅ Here's the Flow: IdentityServer Token Sharing Explained</h3>
<h3>✅ Conclusion</h3>
<ol>
  <li>If your app just needs to call an API, only <code>access_token</code> is needed.</li>
  <li>If your app needs to know who is logged in, <code>id_token</code> is used.</li>
  <li>Both tokens are commonly issued together, but not both are required for API calls.</li>
</ol>
<h2>✅ Here's the Flow: IdentityServer Token Sharing Explained</h2>
<div class="box"><strong>[User]</strong></div>
<div class="arrow">|<br>| 1. Login via IdentityServer<br>v</div>

<div class="box"><strong>[IdentityServer]</strong></div>
<div class="arrow">|<br>| 2. Redirects to Google/Microsoft (external provider)<br>v</div>

<div class="box"><strong>[Google / Microsoft / AzureAD]</strong></div>
<div class="arrow">|<br>| 3. User Authenticates → Sends external <code>id_token</code> to IdentityServer<br>v</div>

<div class="box"><strong>[IdentityServer]</strong></div>
<div class="arrow">|<br>| 4. Validates external <code>id_token</code> → creates local identity<br>|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(maps external claims to internal user claims)<br>|<br>| 5. Issues <strong>its own</strong> <code>access_token</code> + <code>id_token</code> to the frontend/client<br>v</div>

<div class="box"><strong>[Your Application / Angular / .NET]</strong></div>


