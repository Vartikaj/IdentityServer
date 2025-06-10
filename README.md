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

<h3>✅ Here's the Flow: IdentityServer Token Sharing Explained</h3>
![image](https://github.com/user-attachments/assets/3b8f0b97-a7fc-4890-9b28-268edea87603)


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


<h2>Identity Server in ASP.net core</h2>
<h3>🔐 1. ApiScopes</h3>
<pre>
  public static IEnumerable<ApiScope> ApiScopes =>
    new ApiScope[]
    {
        new ApiScope("CustomMiddleWare.write")
    };
</pre>

<h4>✅ What it means:</h4>
<ol>
  <li>ApiScope defines specific permissions or access levels for an API.</li>
  <li>Each scope represents an action or a group of permissions (e.g., read, write).</li>
  <li>In my case:<br/>
"CustomMiddleWare.write" means “this token allows the client to write to the CustomMiddleWare API.”</li>
</ol>
<h3>🔒 2. ApiResources</h3>
<pre>
  public static IEnumerable<ApiResource> ApiResources =>
    new ApiResource[]
    {
        new ApiResource("CustomMiddleWare")
        {
            Scopes = new List<string> { "CustomMiddleWare.write" },
            ApiSecrets = new List<Secret>{new Secret("supersecret".Sha256()) }
        }
    };
</pre>
<h4>✅ What it means:</h4>
<ol>
  <li>ApiResource represents an actual API you want to protect.</li>
  <li>It defines:
  <ol>
    <li>The name of the API (CustomMiddleWare)</li>
    <li>The scopes that apply to this API (CustomMiddleWare.write)</li>
    <li>An optional API secret (used if the API wants to validate incoming tokens or use introspection)</li>
    <li>Think of this as "registering your actual API" in IdentityServer.</li>
  </ol></li>
  <li>In my case:<br/>
"CustomMiddleWare.write" means “this token allows the client to write to the CustomMiddleWare API.”</li>
</ol>
<h3>👤 3. Clients</h3>
<pre>
  public static IEnumerable<Client> Clients =>
    new Client[] {
        new Client
        {
            ClientId = "mvc",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
            ClientSecrets = new [] { new Secret("secret".Sha512()) },
            AllowedScopes = { "CustomMiddleWare.write", "offline_access" },
            ...
        }
    };
</pre>

<h3>IdentityResources</h3>
<p>IdentityResources are directly related to what user information appears in the id_token (and optionally via the UserInfo endpoint). </p>
<pre>
  public static IEnumerable<IdentityResource> IdentityResources =>
    new IdentityResource[]
    {
        new IdentityResources.OpenId(),    // gives you `sub`
        new IdentityResources.Profile()    // gives you name, family_name, etc.
    };
</pre>
<h3>✅ What it means:</h3>
<p>This defines a client application (like an Angular app, MVC app, Postman, etc.)</p>
<p>It tells IdentityServer:</p>
<ul>
  <li>Who the client is (<code>ClientId = "mvc"</code>)</li>
  <li>What grant types it can use:
    <ul>
      <li><code>ResourceOwnerPassword</code> = username/password login</li>
      <li><code>ClientCredentials</code> = machine-to-machine token</li>
    </ul>
  </li>
  <li>What API scopes it can request (<code>CustomMiddleWare.write</code>)</li>
  <li>Whether it supports refresh tokens (<code>offline_access</code>)</li>
  <li>How long the access/refresh tokens should last</li>
</ul>
<h3>🔄 Token Configuration Highlights:</h3>
<table border="1" cellpadding="8" cellspacing="0">
  <thead>
    <tr>
      <th>Property</th>
      <th>Purpose</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><code>AccessTokenLifetime = 300</code></td>
      <td>Access token is valid for 5 minutes</td>
    </tr>
    <tr>
      <td><code>AllowOfflineAccess = true</code></td>
      <td>Allows issuing a refresh token</td>
    </tr>
    <tr>
      <td><code>RefreshTokenUsage = OneTimeOnly</code></td>
      <td>Each refresh token can be used only once</td>
    </tr>
    <tr>
      <td><code>RefreshTokenExpiration = Sliding</code></td>
      <td>Token expiration time extends with each use</td>
    </tr>
    <tr>
      <td><code>SlidingRefreshTokenLifetime = 300</code></td>
      <td>Sliding lifetime is 5 minutes</td>
    </tr>
    <tr>
      <td><code>AbsoluteRefreshTokenLifetime = 600</code></td>
      <td>Max lifetime of refresh token is 10 minutes</td>
    </tr>
  </tbody>
</table>
<h3>🚫 If You Don't Add Them: What Goes Wrong</h3>
<ol>
  <li>
    <strong>❌ If you don't add ApiScopes</strong><br>
    <strong>Error:</strong> Clients won’t be able to request any scopes.<br>
    <strong>Result:</strong> Tokens will either:
    <ul>
      <li>Not be issued</li>
      <li>Or will be missing the expected scopes</li>
    </ul>
    <strong>Impact:</strong> APIs will reject the token as unauthorized or invalid scope.
  </li>

  <li>
    <strong>❌ If you don't add ApiResources</strong><br>
    <strong>Error:</strong> The API is not recognized by IdentityServer as a valid resource.<br>
    <strong>Result:</strong>
    <ul>
      <li>You can't protect your API properly</li>
      <li>You lose the ability to associate scopes with specific APIs</li>
    </ul>
    <strong>Impact:</strong>
    <ul>
      <li>You might issue tokens without properly linking them to an API</li>
      <li>Access control becomes unclear and insecure</li>
    </ul>
  </li>

  <li>
    <strong>❌ If you don't add Clients</strong><br>
    <strong>Error:</strong> No application is authorized to request tokens<br>
    <strong>Result:</strong> IdentityServer will reject all token requests with:<br>
    <code>invalid_client</code><br>
    <strong>Impact:</strong> No frontend or backend app can authenticate or access any protected resource.
  </li>
</ol>

<h3>✅ Why These Are Required</h3>
<table border="1" cellpadding="8" cellspacing="0">
  <thead>
    <tr>
      <th>Component</th>
      <th>Role</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><strong>Clients</strong></td>
      <td>Define who can ask for tokens, which grant types and scopes they're allowed</td>
    </tr>
    <tr>
      <td><strong>ApiScopes</strong></td>
      <td>Define what actions/permissions a client can request on an API</td>
    </tr>
    <tr>
      <td><strong>ApiResources</strong></td>
      <td>Define which APIs are protected and what scopes apply to them</td>
    </tr>
  </tbody>
</table>

<h3>✅ 1. Minimal Working IdentityServer Setup (Without ApiResource)</h3>
<p>This version works only with <strong>ApiScope</strong> and <strong>Client</strong>, which is valid in IdentityServer 6+ (Duende). Good for simple setups.</p>

<h4>🔧 Config.cs</h4>
<pre><code>public static IEnumerable&lt;ApiScope&gt; ApiScopes =&gt; new[]
{
    new ApiScope("api.read")
};

public static IEnumerable&lt;Client&gt; Clients =&gt; new[]
{
    new Client
    {
        ClientId = "simple_client",
        AllowedGrantTypes = GrantTypes.ClientCredentials,
        ClientSecrets = { new Secret("secret".Sha256()) },
        AllowedScopes = { "api.read" }
    }
};</code></pre>

<p>📌 This allows the client to request a token to access <code>"api.read"</code> permission, without linking to a specific <strong>ApiResource</strong>.</p>

<h3>✅ 2. Full Working IdentityServer Setup (With All 3: Client, ApiScope, ApiResource)</h3>
<p>This is the recommended approach for more complex, secure, and multi-API setups.</p>

<h4>🔧 Config.cs</h4>
<pre><code>public static IEnumerable&lt;ApiScope&gt; ApiScopes =&gt; new[]
{
    new ApiScope("api.read"),
    new ApiScope("api.write")
};

public static IEnumerable&lt;ApiResource&gt; ApiResources =&gt; new[]
{
    new ApiResource("my_api")
    {
        Scopes = { "api.read", "api.write" },
        ApiSecrets = { new Secret("supersecret".Sha256()) }
    }
};

public static IEnumerable&lt;Client&gt; Clients =&gt; new[]
{
    new Client
    {
        ClientId = "robust_client",
        AllowedGrantTypes = GrantTypes.ClientCredentials,
        ClientSecrets = { new Secret("secret".Sha256()) },
        AllowedScopes = { "api.read", "api.write" }
    }
};</code></pre>


<h3>🔄 IdentityServer 4 vs IdentityServer 6</h3>
<table border="1" cellpadding="8" cellspacing="0">
  <thead>
    <tr>
      <th>Feature / Aspect</th>
      <th>IdentityServer 4</th>
      <th>IdentityServer 6 (Duende IdentityServer)</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Platform Support</td>
      <td>.NET Core 3.1 / .NET 5</td>
      <td>.NET 6 and later (requires .NET 6+)</td>
    </tr>
    <tr>
      <td>Maintainer</td>
      <td>Free open-source by IdentityServer team</td>
      <td>Commercial product by Duende Software</td>
    </tr>
    <tr>
      <td>License</td>
      <td>Free and Open Source (Apache 2.0)</td>
      <td>Commercial License Required (non-free)</td>
    </tr>
    <tr>
      <td>OIDC / OAuth2 Standards</td>
      <td>Supported (stable, mature)</td>
      <td>Supported with latest specifications</td>
    </tr>
    <tr>
      <td>Maintenance & Support</td>
      <td>No longer maintained (EOL in 2022)</td>
      <td>Actively maintained with enterprise support</td>
    </tr>
    <tr>
      <td>Security Updates</td>
      <td>❌ No new fixes</td>
      <td>✅ Regular patches and security fixes</td>
    </tr>
    <tr>
      <td>Performance Enhancements</td>
      <td>Older token generation and validation</td>
      <td>Optimized for performance, including Redis support</td>
    </tr>
    <tr>
      <td>Device Flow Support</td>
      <td>Limited</td>
      <td>Fully supported</td>
    </tr>
    <tr>
      <td>JWT Enhancements</td>
      <td>Basic</td>
      <td>More flexible token customization & encryption</td>
    </tr>
    <tr>
      <td>Extensibility (Events, Validators)</td>
      <td>Moderate</td>
      <td>Improved middleware extensibility</td>
    </tr>
    <tr>
      <td>Built-in Redis Support</td>
      <td>❌ No</td>
      <td>✅ Yes (operational store, caching, etc.)</td>
    </tr>
    <tr>
      <td>Best For</td>
      <td>Legacy/self-hosted apps in dev/test environments</td>
      <td>Production-grade, secure, and scalable applications</td>
    </tr>
  </tbody>
</table>
