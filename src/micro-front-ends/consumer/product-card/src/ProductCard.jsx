import React,{ Component} from 'react';
import styles from './productcard.module.css';

export default class ProductCard extends Component {
  render(){
  return (
<div className={styles.wrapper}>
  <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
  <div className={styles.container}>
    <div className={styles.top} style={{background: 'url(http://localhost:3000/images/products/1/milk-carton.svg) no-repeat center center'}}></div>
    <div className={styles.bottom}>
      <div className={styles.left}>
        <div className={styles.details}>
          <h1>Milk</h1>
          <p>E250</p>
        </div>
        <div className={styles.buy}><i className="material-icons">add_shopping_cart</i></div>
      </div>
      <div className={styles.right}>
        <div className={styles.done}><i className="material-icons">done</i></div>
        <div className={styles.details}>
          <h1>Chair</h1>
          <p>Added to your cart</p>
        </div>
        <div className={styles.remove}><i className="material-icons">clear</i></div>
      </div>
    </div>
  </div>
  <div className={styles.inside}>
    <div className={styles.icon}><i className="material-icons">info_outline</i></div>
    <div className={styles.contents}>
      <table>
          <tbody>
        <tr>
          <th>Width</th>
          <th>Height</th>
        </tr>
        <tr>
          <td>3000mm</td>
          <td>4000mm</td>
        </tr>
        <tr>
          <th>Something</th>
          <th>Something</th>
        </tr>
        <tr>
          <td>200mm</td>
          <td>200mm</td>
        </tr>
        <tr>
          <th>Something</th>
          <th>Something</th>
        </tr>
        <tr>
          <td>200mm</td>
          <td>200mm</td>
        </tr>
        <tr>
          <th>Something</th>
          <th>Something</th>
        </tr>
        <tr>
          <td>200mm</td>
          <td>200mm</td>
        </tr>
        </tbody>
      </table>
    </div>
  </div>
</div>
    );
}};
