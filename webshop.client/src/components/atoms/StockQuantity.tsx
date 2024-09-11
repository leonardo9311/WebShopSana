import React from 'react';

interface StockQuantityProps {
    quantity: number;
}

const StockQuantity: React.FC<StockQuantityProps> = ({ quantity }) => {
    return <p>Available Stock: {quantity}</p>;
};

export default StockQuantity;
