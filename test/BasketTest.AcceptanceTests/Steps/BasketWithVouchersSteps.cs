﻿using System.Collections.Generic;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BasketTest.AcceptanceTests.Steps
{
    [Binding]
    public class BasketWithVouchersSteps
    {
        private Basket _target = new Basket();

        [Given(@"I have added the following items to my basket:")]
        public void GivenIHaveAddedTheFollowingToMyBasket(IEnumerable<LineItem> lines)
        {
            foreach (var line in lines)
            {
                _target.Add(line);
            }
        }

        [When(@"I apply (.*)")]
        public void WhenIApply(GiftVoucher voucher)
        {
            _target.Apply(voucher);
        }

        [When(@"I apply (.*)")]
        public void WhenIApply(OfferVoucher voucher)
        {
            _target.Apply(voucher);
        }

        [Then(@"my basket total will be £(.*)")]
        public void ThenMyBasketTotalWillBe(decimal total)
        {
            _target.Total.Should().Be(total);
        }

        [Then(@"I will receive a message ""(.*)""")]
        public void ThenIWillReceiveAMessage(string message)
        {
            _target.Messages.Should().HaveCount(1).And.Contain(message);
        }
    }
}
