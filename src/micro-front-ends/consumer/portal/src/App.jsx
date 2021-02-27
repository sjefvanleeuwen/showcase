import React from 'react';

const ProductCard = React.lazy(() => import('product_card/ProductCard'));
const style = {
    display: 'flex',
    justifyContent: 'center',
    alignItems: 'center',
    flexWrap: 'wrap',
};
const App = () => {
    const productCards = Array.from(Array(12).keys());
    return (
        <main>
            <h1>This is the Portal app</h1>
            <div style={style}>
                {productCards.map((id) => (
                    <React.Suspense
                        fallback={<p>...</p>}
                        key={id}
                    >
                        <ProductCard id={id} />
                    </React.Suspense>
                ))}
            </div>
        </main>
    );
};
export default App;
