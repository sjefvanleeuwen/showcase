import React,{ Component} from 'react';
import { QueryRenderer, graphql } from 'react-relay';
import { Environment, Network, RecordSource, Store} from 'relay-runtime';
import environment from './environment';

export default class Products extends Component {

  render(){
  return (
    <QueryRenderer
      environment={environment}
      query={graphql`
        query ProductsQuery($productId: Int!) {
          product(id: $productId) {
            name
            description
          }
        }
      `}
      variables={{
        productId: 1,
      }}
      render={({error, props}) => {
        if (error) {
          return <div>{error.message}</div>;
        } else if (props) {
          return <div>{props.product.name}<br/>{props.product.description}</div>;
        }
        return <div>Loading</div>;
      }}
    />
    );
  }
  

};
