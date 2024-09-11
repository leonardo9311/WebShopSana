import React from 'react';

interface AddToCartButtonProps {
    onAddToCart: () => void;
}

const AddToCartButton: React.FC<AddToCartButtonProps> = ({ onAddToCart }) => {
    return <button onClick={onAddToCart}>Add to Cart</button>;
};

export default AddToCartButton;
