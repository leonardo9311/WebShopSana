import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import ProductPage from './components/pages/ProductPage'
import ShoppingCartPage from './components/pages/ShoppingCartPage';
import Header from './components/organism/Header';
import NotificationContainer from './components/molecules/NotificationContainer'; // Import NotificationContainer

const App: React.FC = () => {
    return (
        <Router>
            <Header />
            <NotificationContainer />
            <div className="container mt-4">
            <Routes>
                <Route path="/" element={<ProductPage />} />
                <Route path="/cart" element={<ShoppingCartPage />} />
                </Routes>
            </div>
        </Router>
    );
};

export default App;
