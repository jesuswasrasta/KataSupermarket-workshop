# Kata Supermarket

[Supermarket Kata](http://codekata.com/kata/kata01-supermarket-pricing/).

## The kata

In Jet Supermarket we have a checkout system that only can do one kind of offers,
based on quantities of the same item (e.g. 1 apple for 50 cents, 3 apples for 1.30 dollars).  
At the moment items are priced individually in cents (e.g. 1 apple costs 50 cents),
while some items are multi-priced: buy _x_ of them, and they’ll cost you _n_ cents.

In fact the current prices are:

|Item       | Unit Price  | Special Price |
|-----------|-------------|---------------|
| apple     | 50          | 3 for 130     |
| pear      | 30          | 2 for 45      |
| pineapple | 220         |               |
| banana    | 60          |               |


Our checkout accepts items in any order, so that if we scan a pear, a pineapple,
and another pear, we’ll recognize the two pear's and price them at 45 cents
(for a total price so far of 265 cents).   
Because the pricing changes frequently, we pass in a set of pricing rules
each time we start handling a checkout transaction.

## Start small

Start making the system able to check individual price: discount will be calculated by hand by the cashier.  
Then start implementing offers.

### The 1<sup>st</sup> User Story

```
As a cashier, 
I want a basic checkout system
so I can let my customers pay for apples
```

#### Acceptance Criteria

```
* When I checkout an apple, the system charges 50 cents
* When I checkout 3 apples, the system charges 150 cents
```

### The 2<sup>nd</sup> User Story

Implement individual price for other fruits in list: _pear_, _pineapple_, _banana_

```
As a cashier, 
I want to add pear, pineapple and banana to the checkout system
so I can speed up the payment process
```

#### Acceptance Criteria

```
* When I checkout 1 pear, the system charges 30 cents
* When I checkout 1 pineapple, the system charges 220 cents
* When I checkout 1 banana, the system charges 60 cents

* When I checkout 2 pear, the system charges 60 cents
* When I checkout 2 pineapple, the system charges 440 cents
* When I checkout 2 banana, the system charges 120 cents
```

### The 3<sup>rd</sup> User Story

```
As a cashier, 
I want to specify offers for items
so my customers will pay less for multiple items purchase
```
#### Acceptance Criteria

```
* When I checkout 3 apples, the system charges 130 cents instead of 150
* When I checkout 2 pears, the system charges 45 cents instead of 60
* When I checkout 2 pineapple, the system charges 440 cents, as there are no offers for pineapples
```

### The 4<sup>th</sup> User Story

```
As a cashier,
I want to add a "take 3 pay 2 offer" kind for items
so my customers will pay less for multiple items purchase
```
#### Acceptance Criteria

```
For the first step, I only want to apply this offers for oranges:
* When I checkout 3 orange, the system charges 90 cents instead of 135
* When I checkout 4 orange, the system charges 135 cents instead of 180
* When I checkout 6 orange, the system charges 180 cents instead of 270
```
### The 5<sup>th</sup> User Story: Fruit Salad offer

```
As a cashier, 
I want to specify this offer: 4 apples, 2 pears, 2 bananas and 1 pineapple for 500
so my customers can make delicious fruit salads :)
```
#### Acceptance Criteria

```
* When I checkout EXACTLY 4 apples, 2 pears, 2 bananas and 1 pineapple, the system charges 500
* All other offers and base prices remains in place
* When I checkout 8 apples, 4 pears, 4 bananas and 2 pineapple, the system charges 1000
* When I checkout 5 apples, 3 pears, 3 bananas and 2 pineapple, the system charges 860 (500+50+30+220+60)
* When I checkout 7 apples, 2 pears, 2 bananas and 1 pineapple, the system charges 630 (500+130)
```
---
### User Story: Payments, show change on display

```
As a cashier, 
I want the cash register to calcultate the change  
so I can avoid silly mistakes with my customers during the payments 
```
#### Acceptance Criteria

```
* I want to tell the cash register the amount of cash my customers gives to me, so it can calculate the change.
  * E.g: If customer buys 1 apple (50 cents) and gives me a 1$ dollar note, the cash register will tell **on the display** 
    |   Total: 50  |
    |    Cash: 100 |
    |  Change: 50  |
```
---
### User Story: Payment by Credit Card

```
As a cashier, 
I want to let my customer pay by credit card 
```
#### Acceptance Criteria

```
* E.g: If customer buys 1 apple (50 cents), on checkout with a valid credit card, the cash register will show on the display: 
    |   0 - Transaction completed successfully |
```
#### Implementation notes
In this scenario, we have an external service that allows the supermarket to pay by credit card.  
This is an external service, we don't own it.  
Fortunately, there is an interface that allows us to know how to call it:

~~~csharp
namespace KataSupermarket;
/// <summary 
/// Credit Card Payment Service
/// </summary>
public interface IPaymentService
{
   /// <summary>   
   /// A cash register must connect to the service before accepting the payment.
   /// </summary>   
   /// <param name="username">The username assigned to the supermarket</param>    
   /// <param name="password">The password assigned to the supermarket</param>    
   /// <returns>Result</returns> 
   /// <example>0 - Connection completed successfully.</example>    
   /// <example>10 - Invalid username or password.</example>    
   /// <example>90 - Connection failed. Please try again later.</example>    
   Result Connect(string username, string password);
   /// <summary>     
   /// This method allows the supermarket to charge the <param name="creditCardNumber"></param> with the specified <param name="totalToPay"></param>.
   /// </summary>    
   /// <param name="creditCardNumber"></param>    
   /// <param name="totalToPay"></param>    
   /// <returns>Result</returns>    
   /// <example>0 - Transaction completed successfully.</example>    
   /// <example>1 - User not connected.</example>    
   /// <example>10 - Insufficient funds.</example>    
   /// <example>20 - Expired credit card.</example>    
   /// <example>30 - Lost or stolen credit card.</example>    
   /// <example>40 - Unusual activity.</example>    
   /// <example>90 - Connection failed. Please try again later.
   ///</example>    
   Result AcceptPayment(string creditCardNumber, int totalToPay);
}
/// <summary>
/// The result of an interaction with the Payment Service 
/// </summary>
public class Result
{
   /// <summary>    
   /// A code that identifies the interaction result.
   /// </summary>    
   public int StatusCode { get; }
   /// <summary>      A human readable message.
   /// </summary>    
   public string Message { get; }
    
   public Result(int statusCode, string message)
   {
        StatusCode = statusCode;
        Message = message;
   }
}
~~~
### Add some more extra feature

Now, the supermarket manager thinks that having more items and offers will boost his earnings; so he wants to:
* add these items:
  * mango -> 155 cents
  * coconut -> 233 cents
  * strawberry -> 120 cents
  * orange -> 45 cents
  * peach -> 40 cents

* implement a new offers system that lets us apply new pricing rules:
  * 3 x 2 offers (pay 2, get 3)
  * combo offers (e.g. buy 3 apple, and you will obtain an additional pear)

* implements the cash payment system
* implements the credit card payment system
  * the government stopped producing 1 and 2 cents coins; every bill/invoice has to be rounded to the nearest multiple of 5, even if paid with debet/credit card
  * we have to manage the cancellation of a product, because it is damaged or the customer decides to return it (e.g. it costs too much and he didn't realize it)

...[to be continued]...

PS: feel free to propose next change request to implement! 😀

---
### An example of the Payment System User Story

```
As a cashier, 
I want to print the fiscal receipt for sold items
so I can collect money from my customers 
```
#### Acceptance Criteria

```
Scenario 1: customer buys items with and without applied offers

Background: 
* I checked out 3 apples for 130 cents instead of 150
* I checked out 2 pears for 45 cents instead of 60
* I checked out 2 pineapple for 440 cents (no offers for pineapples)

* When I close the checkout, a fiscal receipt like this is printed to the console:
```

|Item       | Price           |
|-----------|-----------------|
| apple     | 50x3=~150~ 130  |
| pear      | 30x2=~60~ 45    |
| pineapple | 220x2=440       |
|           |                 |
| TOTAL     | 615             |
|           |                 |
| Goodbye!  |                 |


```
Scenario 2: an item is damaged then subtracted form the list

Background: 
* I checked out 3 apples for 130 cents instead of 150
* I checked out 2 pears for 45 cents instead of 60
* I checked out 2 pineapple for 440 cents (no offers for pineapples)
* I refund 1 pear

* When I close the checkout, a fiscal receipt like this is printed to the console:
```

|Item       | Price           |
|-----------|-----------------|
| apple     | 50x3=~150~ 130  |
| pear      | 30x2=~60~ 45    |
| pineapple | 220x2=440       |
| ~pear~    | ~30x2=60 45~    |
| pear      | 30x1=30         |
|           |                 |
| TOTAL     | 600             |
|           |                 |
| Goodbye!  |                 |


```
Scenario 3: automatic calculation of remainder

Background: 
* I checked out 1 pear for 30 cents

* I close the checkout
* I tell to the customer the total amount
* She gives me a 1 dollar bill
* I enter the received amout in the cash register

* I close the transaction, then a fiscal receipt like this is printed to the console:
```

|Item       | Price           |
|-----------|-----------------|
| pear      | 30              |
|           |                 |
| TOTAL     | 30              |
| --------- | --------------- |
| Received  | 100             |
| Withdraw  | 70              |
|           |                 |
| Goodbye!  |                 |

---
### An example of the Fidelity card User Story

```
As a cashier, 
I want to give a loyalty card that applies an additional 10% discount to some "fidelity products"
so I can build up the loyalty of my customers
```
#### Acceptance Criteria

```
Scenario 1: Customer with fidelity card

Background: 
* Apple is a "fidelity product"
* Customer has fidelity card number 123456 (additional 10% discount)
* There's an offer for apples: 3 apples for 130 cents instead of 150
* There's an offer for pears: 2 pears for 45 cents instead of 60

* I checked out 3 apples
* I checked out 2 pears
* I checked out 2 pineapple

* When I close the checkout, a fiscal receipt like this is printed to the console:
```




|Item       | Price                                                       |
|-----------|-------------------------------------------------------------|
| apple     | Base price: 50x3=~150~; Offer: ~130~; Fidelity: 130-10%=117 |
| pear      | Base price: 30x2=~60~; Offer: 45                            |
| pineapple | Base price: 220x2=440                                       |
|           |                                                             |
| TOTAL     | **602**                                                     |
|           |                                                             |
|           | Fidelity card: 123456                                       |
|           |                                                             |
| Goodbye!  |                                                             |


