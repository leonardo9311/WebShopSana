import { createAsyncThunk } from '@reduxjs/toolkit';
import { Product } from '../../interfaces/productInterface';
import { ProductService } from '../../services/product/productService';
import { RootState } from '../../store/store';
import { ProcessOrderInterface } from '../../interfaces/processOrdeerInterface';
import { ProductToSendDTO } from '../../interfaces/productToSendDTO';


const productService = new ProductService(); 

export const addItemToCart = createAsyncThunk(
    'cart/addItemToCart',
    async (product: Product, { getState, rejectWithValue }) => {
            
            const state = getState() as RootState;
            const existingItem = state.cart.items.find(item => item.productID === product.productID);
            const currentQuantityInCart = existingItem ? existingItem.quantity : 0;
            const totalQuantity = currentQuantityInCart + product.quantity;
            const isAvailable = await productService.checkProductStock(product.productID, totalQuantity);
            if (!isAvailable) {
                return rejectWithValue('Insufficient stock available');
            }

            return {
                ...product,
                quantity: product.quantity,
            };
           
            /*return product;*/
             
    }
);

export const processOrderAsync = createAsyncThunk(
    'cart/processOrder',
    async (_, { getState }) => {
        const state = getState() as RootState;
        const productsInCart = state.cart.items;
          
        const cartItemsToAdd: ProductToSendDTO[] = productsInCart.map((item): ProductToSendDTO => ({
            productID: item.productID,
            quantity: item.quantity,
        } as ProductToSendDTO));

        const orderData: ProcessOrderInterface = {
            customerID: 1,//asumiendo que siempre es el mismo cliente
            cartItems: cartItemsToAdd
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