import React from 'react';

interface QuantityInputProps {
    quantity: number;
    setQuantity: (value: number) => void;
}

const QuantityInput: React.FC<QuantityInputProps> = ({ quantity, setQuantity }) => {
    return (
        <input
            type="number"
            value={quantity}
            min="1"
            onChange={(e) => setQuantity(Number(e.target.value))}
        />
    );
};

export default QuantityInput;
