import React from 'react';

interface PriceProps {
    amount: number;
}

const Price: React.FC<PriceProps> = ({ amount }) => {
    return <p>Price: ${amount.toFixed(2)}</p>;
};

export default Price;
