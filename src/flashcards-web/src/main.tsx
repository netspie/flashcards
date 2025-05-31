import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import { createTheme, ThemeProvider } from "@mui/material";
import About from "./pages/About.tsx";
import Home from "./pages/Home.tsx";
import "./main.css";

import { StyledEngineProvider } from "@mui/material/styles";
import Layout from "./Layout.tsx";
import Create from "./pages/Create.tsx";
import Explore from "./pages/Explore.tsx";
import Pricing from "./pages/Pricing.tsx";
import Dashboard from "./pages/Dashboard.tsx";
import Profile from "./pages/Profile.tsx";
import Teachers from "./pages/Teachers.tsx";

const theme = createTheme({
  typography: {
    fontFamily: "'Noto Sans', sans-serif",
    h1: {
      fontFamily: "'RocknRoll One', sans-serif",
    },
    h2: {
      fontFamily: "'RocknRoll One', sans-serif",
    },
    h3: {
      fontFamily: "'RocknRoll One', sans-serif",
    },
    h4: {
      fontFamily: "'RocknRoll One', sans-serif",
    },
    h5: {
      fontFamily: "'RocknRoll One', sans-serif",
    },
    h6: {
      fontFamily: "'RocknRoll One', sans-serif",
    },
  },
  palette: {
    primary: {
      main: "#000066",
    },
    secondary: {
      main: "#fb7185",
    },
  },
});

const router = createBrowserRouter([
  { path: "/", element: <Home /> },
  { path: "/create", element: <Create /> },
  { path: "/explore", element: <Explore /> },
  { path: "/dashboard", element: <Dashboard /> },
  { path: "/teachers", element: <Teachers /> },
  { path: "/profile", element: <Profile /> },
  { path: "/about", element: <About /> },
  { path: "/contact", element: <About /> },
  { path: "/pricing", element: <Pricing /> },
  { path: "/sign-in", element: <About /> },
]);

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <StyledEngineProvider injectFirst>
      <ThemeProvider theme={theme}>
        <Layout>
          <RouterProvider router={router} />
        </Layout>
      </ThemeProvider>
    </StyledEngineProvider>
  </StrictMode>
);
