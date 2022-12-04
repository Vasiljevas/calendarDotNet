import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { login } from "../api/auth";
import { User } from "../utils/types";

type Props = {
  onLogin: (user: User) => void;
};

export const LoginScreen = ({ onLogin }: Props) => {
  const [email, setEmail] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      const user = await login({ email, password });
      onLogin(user);
      navigate("/");
    } catch (e) {
      if (e instanceof Error) {
        alert(e.message);
      } else {
        alert("Failed to login for a weird reason!");
      }
    }
  };

  return (
    <div className="hero min-h-screen bg-base-200">
      <div className="hero-content flex-col lg:flex-row-reverse mx-32">
        <div className="text-center lg:text-left">
          <h1 className="text-5xl ml-4 font-bold">Login now!</h1>
          <p className="py-6 ml-4">
            If you don't yet have an account - please{" "}
            <Link to={"/register"} className="text-blue-500">
              {" "}
              register your account.
            </Link>
          </p>
        </div>
        <div className="card flex-shrink-0 w-full max-w-sm shadow-2xl bg-base-100">
          <div className="card-body">
            <div className="form-control">
              <label className="label">
                <span className="label-text">Email</span>
              </label>
              <input
                type="email"
                placeholder="email"
                className="input input-bordered"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
              />
            </div>
            <div className="form-control">
              <label className="label">
                <span className="label-text">Password</span>
              </label>
              <input
                type="password"
                placeholder="password"
                className="input input-bordered"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              />
            </div>
            <div className="form-control mt-6">
              <button className="btn btn-primary" onClick={handleLogin}>
                Login
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
