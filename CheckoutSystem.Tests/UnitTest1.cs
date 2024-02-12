using CheckoutSystem;

namespace CheckoutSystem.Tests {
    public class BillCalculatorFixture : IDisposable {
        public BillCalculatorFixture() {
            BillCalculator = new CheckoutBillCalculator();
        }

        public void Dispose() { }

        public CheckoutBillCalculator BillCalculator { get; private set; }
    }

    public class UnitTest1 : IClassFixture<BillCalculatorFixture>{
        private BillCalculatorFixture fixture;

        public UnitTest1(BillCalculatorFixture fixture) {
            this.fixture = fixture;
        }

        [Fact]
        public void EmptyStringInputShouldReturnZero() {
            Assert.Equal(0, fixture.BillCalculator.Calculate(""));
        }

        [Theory]
        [InlineData("A", 50)]
        [InlineData("B", 30)]
        [InlineData("C", 20)]
        [InlineData("D", 15)]
        public void SingleSKUInput(string SKUString, int expected) {
            Assert.Equal(expected, fixture.BillCalculator.Calculate(SKUString));
        }

        [Theory]
        [InlineData("ABC", 100)]
        [InlineData("DAB", 95)]
        [InlineData("ABAAC", 180)]
        [InlineData("ABDBADC", 195)]
        [InlineData("ABADBAABAAA", 400)]
        public void VariableSKUInput(string SKUString, int expected) {
            Assert.Equal(expected, fixture.BillCalculator.Calculate(SKUString));
        }

        [Theory]
        [InlineData("EFGG")]
        [InlineData("123123")]
        [InlineData("2184u12")]
        [InlineData("abcd")]
        public void InvalidInputShouldThrowException(string SKUString) {
            var exception = Assert.Throws<Exception>(() => fixture.BillCalculator.Calculate(SKUString));
        }
    }
}