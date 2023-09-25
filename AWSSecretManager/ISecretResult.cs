namespace AWSSecretManager
{
    public interface ISecretResult
    {
         Task<string> GetSecret();
    }
}
