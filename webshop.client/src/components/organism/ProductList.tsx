import React from 'react';
import { Product } from '../../services/product/productInterfaca';
import ProductCard from '../molecules/ProductCard';

interface ProductListProps {
    products: Product[];
}

const ProductList: React.FC<ProductListProps> = ({ products }) => {
    return (
        <div className="container">
            <div className="row">
                {products.map(product => (
                    <div className="col-md-4 mb-4" key={product.productID}>
                        <ProductCard product={product} />
                    </div>
                ))}
            </div>
        </div>
    );
};

export default ProductList;
