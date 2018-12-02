using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace BasketTest.AcceptanceTests.Steps
{
    [Binding]
    public class BasketWithVouchersSteps
    {
        [Given(@"I have added the following items to my basket:")]
        public void GivenIHaveAddedTheFollowingToMyBasket(IEnumerable<LineItem> lines)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I apply (.*)")]
        public void WhenIApply(GiftVoucher voucher)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I apply (.*)")]
        public void WhenIApply(OfferVoucher voucher)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"my basket total will be £(.*)")]
        public void ThenMyBasketTotalWillBe(decimal total)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I will receive a message ""(.*)""")]
        public void ThenIWillReceiveAMessage(string message)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
