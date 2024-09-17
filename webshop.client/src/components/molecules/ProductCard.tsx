import React, { useState } from 'react';
import { addItemToCart } from '../../store/actions/cartActions';
import { Product } from '../../interfaces/productInterface';
import { AppDispatch } from '../../store/store';
import { useDispatch } from 'react-redux';

interface ProductCardProps {
    product: Product;
  
}

export const ProductCard: React.FC<ProductCardProps> = ({ product }) => {
   
    const dispatch: AppDispatch  = useDispatch(); 
    const [quantity, setQuantity] = useState<number>(1);

    const handleQuantityChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const newQuantity = parseInt(e.target.value, 10);
        setQuantity(newQuantity > 0 ? newQuantity : 1); 
    };

    const handleAddToCart = () => {
        product.quantity = quantity;
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
                <div className="mb-3">
                    <label htmlFor={`quantity-${product.productID}`} className="form-label">Quantity:</label>
                    <input
                        type="number"
                        id={`quantity-${product.productID}`}
                        className="form-control"
                        value={quantity}
                        min={1}
                        onChange={handleQuantityChange}
                    />
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
