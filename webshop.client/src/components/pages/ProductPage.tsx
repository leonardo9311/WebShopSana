import React, { useEffect, useState } from 'react';
import { Product } from '../../services/product/productInterfaca';
import { ProductService } from '../../services/product/productService';
import ProductList from '../organism/ProductList';
import './ProductPage.css';

const ProductPage: React.FC = () => {
    const [products, setProducts] = useState<Product[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);
    const [currentPage, setCurrentPage] = useState<number>(1);
    const productsPerPage = 10; // Define the page size

    const productService = new ProductService();

    useEffect(() => {
        const fetchProducts = async () => {
            setLoading(true);
            try {
                const data = await productService.getProducts(currentPage, productsPerPage);
                setProducts(data);
            } catch (err) {
                setError('Error loading products');
            } finally {
                setLoading(false);
            }
        };

        fetchProducts();
    }, [currentPage]); // Re-fetch products when the page changes

    const handlePageChange = (pageNumber: number) => {
        setCurrentPage(pageNumber);
    };

    return (
        <div>
            <h2>Product List</h2>
            <div className="my-3 ps-3">
                <button
                    disabled={currentPage === 1}
                    onClick={() => handlePageChange(currentPage - 1)}
                >
                    Previous
                </button>
                <span> Page {currentPage} </span>
                <button
                    onClick={() => handlePageChange(currentPage + 1)}
                >
                    Next
                </button>
            </div>
            {/* Muestra un indicador de carga superpuesto */}
            <div style={{ position: 'relative' }}>
                {loading && <div className="loading-overlay">Loading...</div>}
                <ProductList products={products} />
            </div>
        </div>
    );
};

export default ProductPage;
