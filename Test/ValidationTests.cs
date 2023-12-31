using Core.Validations;

namespace Test
{
    public class ValidationTests
    {
        [Fact]
        public void TestsIfRegexIsValidatingEmailCorrectly()
        {
            var email = "valid@email.com";


            Assert.Matches(new EmailValidation().Regex, email);
        }

        [Fact]
        public void TestsIfRegexIsInvalidatingEmailCorrectly()
        {
            var email = "notvalid.email.com";


            Assert.DoesNotMatch(new EmailValidation().Regex, email);
        }

        [Fact]
        public void TestIfValidationMethodValidatesCorrectly()
        {
            var email = "valid@email.com";


            Assert.True(new EmailValidation().Validation(email));
        }

        [Fact]
        public void TestIfValidationMethodInvalidatesCorrectly()
        {
            var email = "notvalid.email.com";


            Assert.False(new EmailValidation().Validation(email));
        }
    }
}