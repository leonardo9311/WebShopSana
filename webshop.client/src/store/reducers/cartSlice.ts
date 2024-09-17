import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { addItemToCart, updateItemQuantityAsync, removeItemAsync } from '../actions/cartActions';
import { Product } from '../../interfaces/productInterface';
import { CartStateInterface } from '../../interfaces/cartStateInterface';

const initialState: CartStateInterface = {
    items: [],
};

const cartSlice = createSlice({
    name: 'cart',
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(addItemToCart.fulfilled, (state, action: PayloadAction<Product>) => {
                const existingItem = state.items.find(item => item.productID === action.payload.productID);
                if (existingItem) {
                    existingItem.quantity += action.payload.quantity;
                } else {
                   
                    state.items.push({
                        productID: action.payload.productID,
                        title: action.payload.title,
                        productCode: action.payload.productCode,
                        price: action.payload.price,
                        stockQuantity: action.payload.stockQuantity,
                        quantity: action.payload.quantity
                    });
                }
            })
            .addCase(updateItemQuantityAsync.fulfilled, (state, action: PayloadAction<{ productId: number; quantity: number }>) => {
                const item = state.items.find(item => item.productID === action.payload.productId);
                if (item) {
                    item.quantity = action.payload.quantity;
                }
            })
            .addCase(removeItemAsync.fulfilled, (state, action: PayloadAction<number>) => {
                state.items = state.items.filter(item => item.productID !== action.payload);
            });
    },
});

export default cartSlice.reducer;
