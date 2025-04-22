import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import { createTheme, ThemeProvider } from "@mui/material";
import MainAppBar from "./MainAppBar.tsx";
import About from "./About.tsx";
import Home from "./Home.tsx";
import './main.css'

import { StyledEngineProvider } from "@mui/material/styles";

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
  { path: "/about", element: <About /> },
]);

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <StyledEngineProvider injectFirst>
      <ThemeProvider theme={theme}>
        <MainAppBar />
        <RouterProvider router={router} />
      </ThemeProvider>
    </StyledEngineProvider>
  </StrictMode>
);
