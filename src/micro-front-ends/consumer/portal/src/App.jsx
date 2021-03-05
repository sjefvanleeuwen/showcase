import React from 'react';
const FormEngineComponent = React.lazy(() => import('form_engine/FormEngineComponent'));

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
            <React.Suspense
                        fallback={<p>...</p>}
                    >
                        <FormEngineComponent />
                    </React.Suspense>
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
            <React.Suspense
                        fallback={<p>...</p>}
                    >
                        <FormEngineComponent />
                    </React.Suspense>
        </main>
    );
};
export default App;
