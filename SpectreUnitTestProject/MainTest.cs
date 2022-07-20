using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using SpectreUnitTestProject.Base;
using UtilityLibrary.LanguageExtensions;

namespace SpectreUnitTestProject
{
    [TestClass]
    public partial class MainTest : TestBase
    {
        [TestMethod]
        [TestTraits(Trait.SpectreConsole)]
        public void StripCodesTest()
        {
            // arrange
            string expected = "File size: 1234";
            int length = 1234;
            string input = $"[red on yellow]File size:[/] [bold]\t{length,-10}[/]";

            // act
            var output = input.StripCodes();

            // assert
            Check.That(expected).Equals(output);
            Check.That("Baz").Equals("[rgb(255,0,0)]Baz[/] ".StripCodes());
        }

        /// <summary>
        /// StripCodes does not work well in this case
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.SpectreConsole)]
        public void StripCodesDoubleTest()
        {
            string input = "[[Hello]] ";
            var output = input.StripCodes();
            Check.That("]").Equals(output);
        }
    }
}
