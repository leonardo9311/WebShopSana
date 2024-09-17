import { createAsyncThunk } from '@reduxjs/toolkit';
import { Product } from '../../interfaces/productInterface';
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

export const processOrderAsync = createAsyncThunk(
    'cart/processOrder',
    async (_, { getState }) => {
        const state = getState() as any; // Get the current state
        const cartItems = state.cart.items;

        const orderData = {
            customerID: 1,
            cartItems: cartItems.map((item: Product) => ({
                productId: item.productID,
                quantity: item.quantity,
            })),
        };
        

    
        const response = await productService.processOrder(orderData);
    
        return response;
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