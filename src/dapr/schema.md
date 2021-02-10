# Schema Types

<details>
  <summary><strong>Table of Contents</strong></summary>

  * [Query](#query)
  * [Mutation](#mutation)
  * [Objects](#objects)
    * [BasketItem](#basketitem)
    * [Customer](#customer)
    * [Inventory](#inventory)
    * [Payment](#payment)
    * [Product](#product)
    * [UpsertBasketItemResult](#upsertbasketitemresult)
  * [Inputs](#inputs)
    * [UpsertBasketItemInput](#upsertbasketiteminput)
  * [Scalars](#scalars)
    * [Boolean](#boolean)
    * [DateTime](#datetime)
    * [Float](#float)
    * [Int](#int)
    * [Name](#name)
    * [String](#string)

</details>

## Query
<table>
<thead>
<tr>
<th align="left">Field</th>
<th align="right">Argument</th>
<th align="left">Type</th>
<th align="left">Description</th>
</tr>
</thead>
<tbody>
<tr>
<td colspan="2" valign="top"><strong>baskets</strong></td>
<td valign="top">[<a href="#basketitem">BasketItem</a>]</td>
<td>

Gets all baskets

</td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>basket</strong></td>
<td valign="top"><a href="#basketitem">BasketItem</a></td>
<td>

Gets a basket item on primary key

</td>
</tr>
<tr>
<td colspan="2" align="right" valign="top">id</td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>basketForCustomer</strong></td>
<td valign="top">[<a href="#basketitem">BasketItem</a>]</td>
<td>

Gets a basket items for a customer by customer identity

</td>
</tr>
<tr>
<td colspan="2" align="right" valign="top">id</td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>customers</strong></td>
<td valign="top">[<a href="#customer">Customer</a>]</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>customer</strong></td>
<td valign="top"><a href="#customer">Customer</a></td>
<td></td>
</tr>
<tr>
<td colspan="2" align="right" valign="top">id</td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>get</strong></td>
<td valign="top">[<a href="#inventory">Inventory</a>]</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>inventory</strong></td>
<td valign="top"><a href="#inventory">Inventory</a></td>
<td></td>
</tr>
<tr>
<td colspan="2" align="right" valign="top">id</td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>payments</strong></td>
<td valign="top">[<a href="#payment">Payment</a>]</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>product</strong></td>
<td valign="top"><a href="#payment">Payment</a></td>
<td></td>
</tr>
<tr>
<td colspan="2" align="right" valign="top">id</td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>products</strong></td>
<td valign="top">[<a href="#product">Product</a>]</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>product_product</strong></td>
<td valign="top"><a href="#product">Product</a></td>
<td></td>
</tr>
<tr>
<td colspan="2" align="right" valign="top">id</td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>mybasket</strong></td>
<td valign="top">[<a href="#basketitem">BasketItem</a>!]!</td>
<td>

This is an extended query which shows a basket for the current logged in customer along with the products. This view is in accordance with the UX design and contains delegated fields from the inventory and product database

</td>
</tr>
</tbody>
</table>

## Mutation
<table>
<thead>
<tr>
<th align="left">Field</th>
<th align="right">Argument</th>
<th align="left">Type</th>
<th align="left">Description</th>
</tr>
</thead>
<tbody>
<tr>
<td colspan="2" valign="top"><strong>upsertBasketItem</strong></td>
<td valign="top"><a href="#upsertbasketitemresult">UpsertBasketItemResult</a></td>
<td></td>
</tr>
<tr>
<td colspan="2" align="right" valign="top">input</td>
<td valign="top"><a href="#upsertbasketiteminput">UpsertBasketItemInput</a></td>
<td></td>
</tr>
</tbody>
</table>

## Objects

### BasketItem

This is a basket item. Multiple items form the shopping basket for a customer.

<table>
<thead>
<tr>
<th align="left">Field</th>
<th align="right">Argument</th>
<th align="left">Type</th>
<th align="left">Description</th>
</tr>
</thead>
<tbody>
<tr>
<td colspan="2" valign="top"><strong>basketItemId</strong></td>
<td valign="top"><a href="#int">Int</a>!</td>
<td>

Unique Id of the basket item

</td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>customerId</strong></td>
<td valign="top"><a href="#int">Int</a>!</td>
<td>

Customer to basket item relation

</td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>productId</strong></td>
<td valign="top"><a href="#int">Int</a>!</td>
<td>

Product to basket item relation

</td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>quantity</strong></td>
<td valign="top"><a href="#int">Int</a>!</td>
<td>

Quantity of the product in the basket item

</td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>name</strong></td>
<td valign="top"><a href="#string">String</a></td>
<td>

delegates the name of the product in the basket from product

</td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>description</strong></td>
<td valign="top"><a href="#string">String</a></td>
<td>

delegates the description of the product in the basket from product

</td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>unitPrice</strong></td>
<td valign="top"><a href="#float">Float</a></td>
<td>

delegates the unit price of the product

</td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>inStock</strong></td>
<td valign="top"><a href="#int">Int</a></td>
<td>

delegates the available stock of the product in the basket from the inventory

</td>
</tr>
</tbody>
</table>

### Customer

<table>
<thead>
<tr>
<th align="left">Field</th>
<th align="right">Argument</th>
<th align="left">Type</th>
<th align="left">Description</th>
</tr>
</thead>
<tbody>
<tr>
<td colspan="2" valign="top"><strong>customerId</strong></td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>name</strong></td>
<td valign="top"><a href="#string">String</a></td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>birthdate</strong></td>
<td valign="top"><a href="#datetime">DateTime</a>!</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>username</strong></td>
<td valign="top"><a href="#string">String</a></td>
<td></td>
</tr>
</tbody>
</table>

### Inventory

<table>
<thead>
<tr>
<th align="left">Field</th>
<th align="right">Argument</th>
<th align="left">Type</th>
<th align="left">Description</th>
</tr>
</thead>
<tbody>
<tr>
<td colspan="2" valign="top"><strong>productId</strong></td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>quantity</strong></td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
</tbody>
</table>

### Payment

<table>
<thead>
<tr>
<th align="left">Field</th>
<th align="right">Argument</th>
<th align="left">Type</th>
<th align="left">Description</th>
</tr>
</thead>
<tbody>
<tr>
<td colspan="2" valign="top"><strong>paymentId</strong></td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>basketId</strong></td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>customerId</strong></td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>total</strong></td>
<td valign="top"><a href="#float">Float</a>!</td>
<td></td>
</tr>
</tbody>
</table>

### Product

<table>
<thead>
<tr>
<th align="left">Field</th>
<th align="right">Argument</th>
<th align="left">Type</th>
<th align="left">Description</th>
</tr>
</thead>
<tbody>
<tr>
<td colspan="2" valign="top"><strong>productId</strong></td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>name</strong></td>
<td valign="top"><a href="#string">String</a></td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>description</strong></td>
<td valign="top"><a href="#string">String</a></td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>unitPrice</strong></td>
<td valign="top"><a href="#float">Float</a>!</td>
<td></td>
</tr>
</tbody>
</table>

### UpsertBasketItemResult

<table>
<thead>
<tr>
<th align="left">Field</th>
<th align="right">Argument</th>
<th align="left">Type</th>
<th align="left">Description</th>
</tr>
</thead>
<tbody>
<tr>
<td colspan="2" valign="top"><strong>id</strong></td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>customerId</strong></td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>productId</strong></td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>quantity</strong></td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
</tbody>
</table>

## Inputs

### UpsertBasketItemInput

<table>
<thead>
<tr>
<th colspan="2" align="left">Field</th>
<th align="left">Type</th>
<th align="left">Description</th>
</tr>
</thead>
<tbody>
<tr>
<td colspan="2" valign="top"><strong>id</strong></td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>customerId</strong></td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>productId</strong></td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
<tr>
<td colspan="2" valign="top"><strong>quantity</strong></td>
<td valign="top"><a href="#int">Int</a>!</td>
<td></td>
</tr>
</tbody>
</table>

## Scalars

### Boolean

The `Boolean` scalar type represents `true` or `false`.

### DateTime

The `DateTime` scalar represents an ISO-8601 compliant date time type.

### Float

The `Float` scalar type represents signed double-precision fractional values as specified by [IEEE 754](http://en.wikipedia.org/wiki/IEEE_floating_point).

### Int

The `Int` scalar type represents non-fractional signed whole numeric values. Int can represent values between -(2^31) and 2^31 - 1.

### Name

The name scalar represents a valid GraphQL name as specified in the spec and can be used to refer to fields or types.

### String

The `String` scalar type represents textual data, represented as UTF-8 character sequences. The String type is most often used by GraphQL to represent free-form human-readable text.

