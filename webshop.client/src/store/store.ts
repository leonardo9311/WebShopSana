// store.ts

import { configureStore, combineReducers } from '@reduxjs/toolkit';
import cartReducer from './reducers/cartSlice';

// Combinar múltiples reducers
const rootReducer = combineReducers({
    cart: cartReducer,
});


const preloadedState = {
    cart: {
        items: JSON.parse(localStorage.getItem('cart') || '[]'),
    },
};

// Configurar el store
const store = configureStore({
    reducer: rootReducer,
    preloadedState,
    devTools: process.env.NODE_ENV !== 'production',
});


store.subscribe(() => {
    localStorage.setItem('cart', JSON.stringify(store.getState().cart.items));
});

export type RootState = ReturnType<typeof rootReducer>;
export type AppDispatch = typeof store.dispatch;
export default store;
