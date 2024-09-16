import React from 'react';
import { addItemToCart } from '../../store/actions/cartActions';
import { Product } from '../../services/product/productInterfaca';
import { AppDispatch } from '../../store/store';
import { useDispatch } from 'react-redux';

interface ProductCardProps {
    product: Product;
  
}

export const ProductCard: React.FC<ProductCardProps> = ({ product }) => {
   
    const dispatch: AppDispatch  = useDispatch(); 

    const handleAddToCart = () => {

        dispatch(addItemToCart(product));
       
    };

    return (
        <div className="card product-card">
            <div className="card-body d-flex flex-column">
                <div className="flex-grow-1">
                    <h5 className="card-title">{product.title}</h5>
                    <p className="card-text">Product Code: {product.productCode}</p>
                    <p className="card-text">{product.description}</p>
                    <p className="card-text">Price: ${product.price.toFixed(2)}</p>
                    <p className="card-text">Stock: {product.stockQuantity}</p>
                </div>

                <button
                    className="btn btn-primary align-self-end mt-2" // Usando align-self-end para alinear a la derecha
                    onClick={handleAddToCart}
                    disabled={product.stockQuantity === 0}
                >
                    Add to Cart
                </button>
            </div>
        </div>
    );
};

export default ProductCard;
