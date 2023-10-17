import SwedbankBlock from "../../elements/blocks/common/swedbank-block";
import {PaymentMethods} from "../../../support/enums";

describe('Pay with Credit card', () => {
    beforeEach(() => {
        cy.visit('https://localhost:5001')
    });
    
    it('Should succeed payment and create cancellation', () => {

        //Add to cart and go to checkout
        cy.get('[data-automation="button-addtocart"]').first().click()
        cy.get('[data-automation="button-checkout"]').first().click()

        new SwedbankBlock().payWithSwedbank(PaymentMethods.card);

        cy.get('h2', {timeout: 30000}).then(($h) => {
            expect($h).to.contain('Thanks!');

            cy.getByAutomation('paymentorderlink').then(($paymentOrderLink) => {
                let paymentOrderLink = $paymentOrderLink.text();
                cy.getByAutomation('orderslink', true, {timeout: 30000}).click();

                cy.get('[data-paymentorderlink="' + paymentOrderLink + '"]').within(($paymentOrder) => {
                    cy.getByAutomation('a-paymentordercancel').should('be.visible').click();
                });
                
                cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');
            })
        });
    })
    
    
    it('Should succeed payment and create capture and reversal', () => {

        //Add to cart and go to checkout
        cy.get('[data-automation="button-addtocart"]').first().click()
        cy.get('[data-automation="button-checkout"]').first().click()

        new SwedbankBlock().payWithSwedbank(PaymentMethods.card);

        cy.get('h2', {timeout: 30000}).then(($h) => {
            expect($h).to.contain('Thanks!');

            cy.getByAutomation('paymentorderlink').then(($paymentOrderLink) => {
                let paymentOrderLink = $paymentOrderLink.text();
                cy.getByAutomation('orderslink', true, {timeout: 30000}).click();

                cy.get('[data-paymentorderlink="' + paymentOrderLink + '"]').within(($paymentOrder) => {
                    cy.getByAutomation('a-paymentordercapture').should('be.visible').click();
                });
                cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');

                cy.get('[data-paymentorderlink="' + paymentOrderLink + '"]').within(($paymentOrder) => {
                    cy.getByAutomation('a-paymentorderreversal').should('be.visible').click();
                });

                cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');
            })
        });
    })
})


describe('Pay with 3DS Credit card', () => {
    beforeEach(() => {
        cy.visit('https://localhost:5001')
    });

    it('Should succeed payment and create cancellation', () => {

        //Add to cart and go to checkout
        cy.get('[data-automation="button-addtocart"]').first().click()
        cy.get('[data-automation="button-checkout"]').first().click()

        new SwedbankBlock().payWithSwedbank(PaymentMethods.card3ds, () => {
            cy.iframeLoaded(
                'iframe[src^="https://ecom.externalintegration.payex.com/creditcard"]',
                '#otp',
                30,
                ($iframe) => {
                    cy.findInIframe($iframe, '#otp').type('1234');
                    cy.findInIframe($iframe, '#sendOtp').click();
                })
        });

        cy.get('h2', {timeout: 30000}).then(($h) => {
            expect($h).to.contain('Thanks!');

            cy.getByAutomation('paymentorderlink').then(($paymentOrderLink) => {
                let paymentOrderLink = $paymentOrderLink.text();
                cy.getByAutomation('orderslink', true, {timeout: 30000}).click();

                cy.get('[data-paymentorderlink="' + paymentOrderLink + '"]').within(($paymentOrder) => {
                    cy.getByAutomation('a-paymentordercancel').should('be.visible').click();
                });

                cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');
            })
        });
    })
    
    it('Should fail to complete payment', () => {

        //Add to cart and go to checkout
        cy.get('[data-automation="button-addtocart"]').first().click()
        cy.get('[data-automation="button-checkout"]').first().click()

        new SwedbankBlock().payWithSwedbank(PaymentMethods.card3ds, () => {
            cy.iframeLoaded(
                'iframe[src^="https://ecom.externalintegration.payex.com/creditcard"]',
                '#otp',
                30,
                ($iframe) => {
                    cy.findInIframe($iframe, '#otp').type('1111');
                    cy.findInIframe($iframe, '#sendOtp').click();
                })
        });

        cy.iframeLoaded(
            'iframe[src^="https://ecom.externalintegration.payex.com/checkout"]',
            "#creditcard",
            30,
            ($iframe) => {
                cy.findInIframe($iframe, "#view-creditcard").within(() => {
                    cy.iframeLoaded(
                        'iframe[src^="https://ecom.externalintegration.payex.com/creditcard"]',
                        "#status-message",
                        30,
                        ($iframe) => {
                            cy.findInIframe($iframe, '#status-message').should('have.class', 'warning');
                        });
                });
            });
    });

    it('Should succeed payment and create capture and reversal', () => {

        //Add to cart and go to checkout
        cy.get('[data-automation="button-addtocart"]').first().click()
        cy.get('[data-automation="button-checkout"]').first().click()

        new SwedbankBlock().payWithSwedbank(PaymentMethods.card3ds, () => {
            cy.iframeLoaded(
                'iframe[src^="https://ecom.externalintegration.payex.com/creditcardv3"]',
                '#otp',
                30,
                ($iframe) => {
                    cy.findInIframe($iframe, '#otp').type('1234');
                    cy.findInIframe($iframe, '#sendOtp').click();
                });
        });

        cy.get('h2', {timeout: 30000}).then(($h) => {
            expect($h).to.contain('Thanks!');

            cy.getByAutomation('paymentorderlink').then(($paymentOrderLink) => {
                let paymentOrderLink = $paymentOrderLink.text();
                cy.getByAutomation('orderslink', true, {timeout: 30000}).click();

                cy.get('[data-paymentorderlink="' + paymentOrderLink + '"]').within(($paymentOrder) => {
                    cy.getByAutomation('a-paymentordercapture').should('be.visible').click();
                });
                cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');

                cy.get('[data-paymentorderlink="' + paymentOrderLink + '"]').within(($paymentOrder) => {
                    cy.getByAutomation('a-paymentorderreversal').should('be.visible').click();
                });

                cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');
            })
        });
    })
})