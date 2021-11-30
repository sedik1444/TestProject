namespace TestProject.Entities
{
    public class Config
    {
        public UserCredentials UserCredentials { get; set; }
        public RecipientAddress RecipientAddress { get; set; }
        public URL URL { get; set; }
        public ValidData ValidData { get; set; }
        

    }
    
    public class UserCredentials
    {
        public  string Username { get; set; }
        public  string Password { get; set; }  
    }

    public class RecipientAddress
    {
        public  string RecipientEmailAddress { get; set; }
    }

    public class ValidData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Expirience { get; set; }
        public string Profession { get; set; }
        public string Education { get; set; }
        public string Comment { get; set; }
    } 

    public class URL
    {
        public Etsy Etsy { get; set; }
        public MailRu MailRu { get; set; }
        public GlobalSQA GlobalSQA { get; set; }
        public Google Google { get; set; }
        public Selenium Selenium { get; set; }
    }

    public class Etsy
    {
        public string EtsyURL { get; set; }
    }
    
    public class MailRu
    {
        public string LoginPageURL { get; set; }
        public string AccountPageURL { get; set; }
    }
    
    public class GlobalSQA
    {
        public string Default { get; set; }
        public string DropDownMenuPageURL { get; set; }
        public string SamplePageTestURL { get; set; }
    }

    public class Google
    {
        public string GoogleSearchURL { get; set; }
    }

    public class Selenium
    {
        public string SeleniumMainPageURL { get; set; }
    }

}