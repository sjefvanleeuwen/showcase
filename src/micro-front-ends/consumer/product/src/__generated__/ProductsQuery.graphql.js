/**
 * @flow
 */

/* eslint-disable */

'use strict';

/*::
import type { ConcreteRequest } from 'relay-runtime';
export type ProductsQueryVariables = {|
  productId: number
|};
export type ProductsQueryResponse = {|
  +product: ?{|
    +name: ?string,
    +description: ?string,
  |}
|};
export type ProductsQuery = {|
  variables: ProductsQueryVariables,
  response: ProductsQueryResponse,
|};
*/


/*
query ProductsQuery(
  $productId: Int!
) {
  product(id: $productId) {
    name
    description
  }
}
*/

const node/*: ConcreteRequest*/ = (function(){
var v0 = [
  {
    "defaultValue": null,
    "kind": "LocalArgument",
    "name": "productId"
  }
],
v1 = [
  {
    "alias": null,
    "args": [
      {
        "kind": "Variable",
        "name": "id",
        "variableName": "productId"
      }
    ],
    "concreteType": "Product",
    "kind": "LinkedField",
    "name": "product",
    "plural": false,
    "selections": [
      {
        "alias": null,
        "args": null,
        "kind": "ScalarField",
        "name": "name",
        "storageKey": null
      },
      {
        "alias": null,
        "args": null,
        "kind": "ScalarField",
        "name": "description",
        "storageKey": null
      }
    ],
    "storageKey": null
  }
];
return {
  "fragment": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Fragment",
    "metadata": null,
    "name": "ProductsQuery",
    "selections": (v1/*: any*/),
    "type": "Query",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Operation",
    "name": "ProductsQuery",
    "selections": (v1/*: any*/)
  },
  "params": {
    "cacheID": "a6c545236f6c20af13a15d9c32a3bd98",
    "id": null,
    "metadata": {},
    "name": "ProductsQuery",
    "operationKind": "query",
    "text": "query ProductsQuery(\n  $productId: Int!\n) {\n  product(id: $productId) {\n    name\n    description\n  }\n}\n"
  }
};
})();
// prettier-ignore
(node/*: any*/).hash = '9417d62217203978ed5a00c2fcede825';

module.exports = node;
