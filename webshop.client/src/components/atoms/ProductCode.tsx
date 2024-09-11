import React from 'react';

interface ProductCodeProps {
    code: string;
}

const ProductCode: React.FC<ProductCodeProps> = ({ code }) => {
    return <p>Product Code: {code}</p>;
};

export default ProductCode;
