import React from 'react';
import { AppDispatch } from '../../store/store';
import { useDispatch } from 'react-redux';
import { removeItemAsync, updateItemQuantityAsync } from '../../store/actions/cartActions';

interface CartItemProps {
    item: {
        productID: number;
        title: string;
        price: number;
        quantity: number;
        productCode: string;
        stockQuantity: number;
        
    };

}

const CartItem: React.FC<CartItemProps> = ({ item}) => {
    const dispatch: AppDispatch = useDispatch();

    const handleIncreaseQuantity = () => {
        if (item.quantity < item.stockQuantity) {
            dispatch(updateItemQuantityAsync({ productId: item.productID, quantity: item.quantity + 1 }));
        }
    };

    const handleDecreaseQuantity = () => {
        if (item.quantity > 1) {
            dispatch(updateItemQuantityAsync({ productId: item.productID, quantity: item.quantity - 1 }));
        }
    };

    const handleRemove = () => {
        dispatch(removeItemAsync(item.productID));
    };

    return (
        <div className="cart-item d-flex align-items-center justify-content-between mb-3">
       
            <div className="product-details flex-grow-1 ml-3">
                <h5 className="product-title">{item.title}</h5>
                <p className="product-code">Item No. {item.productCode}</p>
                <p className="stock-quantity" style={{ color: 'green' }}>
                    {item.stockQuantity} in stock
                </p>
            </div>

        
            <div className="product-price me-3">
                  &euro;  {(item.price * item.quantity).toFixed(2)}
            </div>

          
            <div className="quantity-controls d-flex align-items-center">
                <button className="btn btn-outline-primary" onClick={handleDecreaseQuantity}>-</button>
                <input type="text" value={item.quantity} readOnly className="quantity-input form-control mx-2 text-center" style={{ width: '50px' }} />
                <button className="btn btn-outline-primary" onClick={handleIncreaseQuantity}>+</button>
            </div>

          
            <button className="btn btn-danger ms-3" onClick={handleRemove}>Remove</button>
        </div>
    );
};


export default CartItem;
