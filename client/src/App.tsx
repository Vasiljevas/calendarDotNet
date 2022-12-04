import { useState } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import { NavBar } from "./components/Navbar";
import AdminRoute from "./Routes/AdminRoute";
import PrivateRoute from "./Routes/PrivateRoute";
import {
  LoginScreen,
  MainScreen,
  NotFoundScreen,
  RegisterScreen,
  UserScreen,
} from "./screens";
import AdminScreen from "./screens/AdminScreen";
import { User } from "./utils/types";

function App() {
  const [user, setUser] = useState<User | undefined>();

  const isAuthenticated = !!user;

  const handleUserUpdate = (user: User) => {
    setUser(user);
  };

  const handleLogout = () => {
    setUser(undefined);
  };

  return (
    <>
      <BrowserRouter>
        <NavBar onLogout={handleLogout} user={user} />
        <Routes>
          <Route
            path="/"
            element={
              <PrivateRoute isAuthenticated={isAuthenticated}>
                <MainScreen />
              </PrivateRoute>
            }
          />
          <Route
            path="/user/:userId"
            element={
              <PrivateRoute isAuthenticated={isAuthenticated}>
                <UserScreen />
              </PrivateRoute>
            }
          />
          <Route
            path="/login"
            element={<LoginScreen onLogin={handleUserUpdate} />}
          />
          <Route
            path="/register"
            element={<RegisterScreen onRegister={handleUserUpdate} />}
          />
          <Route
            path="/admin"
            element={
              <AdminRoute isAuthenticated={isAuthenticated} role={user?.role}>
                <AdminScreen />
              </AdminRoute>
            }
          />
          <Route path="/*" element={<NotFoundScreen />} />
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;
