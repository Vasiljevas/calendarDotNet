import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./App.css";
import { NavBar } from "./components/Navbar";
import { LoginScreen, MainScreen, NotFoundScreen, UserScreen } from "./screens";

function App() {
  return (
    <>
      <NavBar />
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<MainScreen />} />
          <Route path="/user/:userId" element={<UserScreen />} />
          <Route path="/login" element={<LoginScreen />} />
          <Route path="/*" element={<NotFoundScreen />} />
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;
