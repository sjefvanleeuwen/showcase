import React from 'react';
import ProductCard from './ProductCard';
import Products from './Products';
const App = () => {
    return (
        <main>
            <h1>This is the product card micro front-end</h1>
            <ProductCard day={1} />
            <h1>This is the product catalog micro-front end</h1>
            <Products />
        </main>
    );
};
export default App;
