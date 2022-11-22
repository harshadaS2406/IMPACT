namespace System.IdentityModel.Tokens
{
    internal class JwtSecurityToken
    {
        private JwtSecurityToken token;

        public JwtSecurityToken(JwtSecurityToken token)
        {
            this.token = token;
        }
    }
}