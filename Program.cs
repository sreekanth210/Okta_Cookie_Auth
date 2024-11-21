var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookie_Scheme";
    options.DefaultChallengeScheme = "OpenId";
})
.AddCookie("Cookie_Scheme", options =>
{
    options.Cookie.Name = "Cookie_Name";
})
.AddOpenIdConnect("OpenId", options =>
{
    options.ClientId = builder.Configuration["Okta:ClientId"];
    options.ClientSecret = builder.Configuration["Okta:ClientSecret"];
    options.Authority = builder.Configuration["Okta:Domain"];
    options.ResponseType = "code";
    options.SaveTokens = true;
    options.UseTokenLifetime = true;
    options.CallbackPath = "/authorization-code/callback";
    /*options.SignedOutCallbackPath = "/Home/Index";*/ // Interuptiong the code find why thi is used after

    //Forces the user every time to varify it's self when cleared all cookies even browser open
    //If skiped won't ask every time to varify untile okta session experired.
    /*options.Events.OnRedirectToIdentityProvider = context =>
    {
        // will ask you every time okta login credentials(password and code(Authcode from mobile app(okta)) when cookies are deleted         
        context.ProtocolMessage.Prompt = "login";

        //if Promt = "login" and specifed this this will skips the username if correct else ask both(uid, pawd and code)
        context.ProtocolMessage.LoginHint = "sreekanth.ankirapalli@tcs.com";

        //According to security purpose Okta not pre-fills the password insted which rewrites the user name text box of above data(username)
        *//*context.ProtocolMessage.LoginHint = "Sree1243@9676329182";*//*

        return Task.CompletedTask;
    };*/

    options.Scope.Add("openid");
    options.Scope.Add("profile");
    options.Scope.Add("email");

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
