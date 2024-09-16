import { createAsyncThunk } from '@reduxjs/toolkit';
import { Product } from '../../services/product/productInterfaca';
import { ProductService } from '../../services/product/productService'; 

const productService = new ProductService(); 

export const addItemToCart = createAsyncThunk(
    'cart/addItemToCart',
    async (product: Product) => {

        const isAvailable = await productService.checkProductStock(product.productID, 1);       
        if (!isAvailable) {
            throw new Error('Insufficient stock available');
        }       
        return product;
    }
);


export const updateItemQuantityAsync = createAsyncThunk(
    'cart/updateItemQuantity',
    async ({ productId, quantity }: { productId: number; quantity: number }) => {

        return { productId, quantity };
    }
);


export const removeItemAsync = createAsyncThunk(
    'cart/removeItem',
    async (productId: number) => {
    
        return productId;
    }
);