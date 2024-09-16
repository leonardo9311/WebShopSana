import React, { useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import CartItem from '../molecules/CartItem';
import { updateItemQuantityAsync, removeItemAsync } from '../../store/actions/cartActions';
import { RootState } from '../../store/store';
import { AppDispatch } from '../../store/store';

const ShoppingCart: React.FC = () => {
    const dispatch: AppDispatch = useDispatch();
    const cartItems = useSelector((state: RootState) => state.cart.items);

    const [total, setTotal] = useState<number>(0);

    useEffect(() => {
        const calculateTotal = () => {
            let totalAmount = 0;
            cartItems.forEach(item => {
                totalAmount += item.price * item.quantity;
            });
            setTotal(totalAmount);
        };

        calculateTotal();
    }, [cartItems]);

    // Manejar cambio de cantidad
    const handleQuantityChange = (productId: number, quantity: number) => {
        dispatch(updateItemQuantityAsync({ productId, quantity })); 
    };

    // Manejar eliminación del producto
    const handleRemoveFromCart = (productId: number) => {
        dispatch(removeItemAsync(productId));
    };

    return (
        <div>
            <h1>Shopping Cart</h1>
            <ul>
                {cartItems.map((item) => (
                    <CartItem
                        key={item.id}
                        item={item}
                        onQuantityChange={handleQuantityChange}
                        onRemove={() => handleRemoveFromCart(item.id)}
                    />
                ))}
            </ul>
            <div>
                <h3>Total: ${total.toFixed(2)}</h3>
                <button onClick={() => console.log('Order processed')}>Process Order</button>
            </div>
        </div>
    );
};

export default ShoppingCart;
