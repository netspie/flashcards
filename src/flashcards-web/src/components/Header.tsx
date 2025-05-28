import RocketLaunchIcon from '@mui/icons-material/RocketLaunch';
import AddCircleOutlineIcon from "@mui/icons-material/AddCircleOutline";
import MenuIcon from "@mui/icons-material/Menu";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import Container from "@mui/material/Container";
import IconButton from "@mui/material/IconButton";
import Menu from "@mui/material/Menu";
import MenuItem from "@mui/material/MenuItem";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import * as React from "react";

function Header() {
  const [anchorElNav, setAnchorElNav] = React.useState<null | HTMLElement>(
    null
  );

  const handleOpenNavMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElNav(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  return (
    <AppBar position="static" color="transparent" sx={{ boxShadow: "none" }}>
      <Container maxWidth="xl">
        <Toolbar disableGutters>
          <IconButton
            size="large"
            aria-label="account of current user"
            aria-controls="menu-appbar"
            aria-haspopup="true"
            href="/"
            color="inherit"
            sx={{ display: { xs: "none", md: "flex" } }}
          >
            <RocketLaunchIcon color="primary" />
          </IconButton>
          <Typography
              variant="h6"
              noWrap
              component="a"
              color="primary"
              href="/"
              sx={{
                mr: 2,
                display: { xs: "none", md: "flex" },
                flexGrow: 1,
                fontWeight: 700,
                textDecoration: "none",
                textTransform: "up"
              }}
            >
              Flashcards
            </Typography>
          <Box sx={{ display: { xs: "flex", md: "none" }, width: "fit" }}>
            <IconButton
              size="large"
              aria-label="account of current user"
              aria-controls="menu-appbar"
              aria-haspopup="true"
              onClick={handleOpenNavMenu}
              color="inherit"
            >
              <MenuIcon />
            </IconButton>
            <Menu
              id="menu-appbar"
              anchorEl={anchorElNav}
              anchorOrigin={{
                vertical: "bottom",
                horizontal: "left",
              }}
              keepMounted
              transformOrigin={{
                vertical: "top",
                horizontal: "left",
              }}
              open={Boolean(anchorElNav)}
              onClose={handleCloseNavMenu}
              sx={{ display: { xs: "block", md: "none" } }}
            >
              <MenuItem key="home" href="/">
                <Typography sx={{ textAlign: "center" }}>Home</Typography>
              </MenuItem>
              <MenuItem key="create" href="/create">
                <Typography sx={{ textAlign: "center" }}>Create</Typography>
              </MenuItem>
              <MenuItem key="explore" href="/explore">
                <Typography sx={{ textAlign: "center" }}>Explore</Typography>
              </MenuItem>
              <MenuItem key="pricing" href="/pricing">
                <Typography sx={{ textAlign: "center" }}>Pricing</Typography>
              </MenuItem>
              <MenuItem key="about" href="/about">
                <Typography sx={{ textAlign: "center" }}>About</Typography>
              </MenuItem>
              <MenuItem key="contact" href="/contact">
                <Typography sx={{ textAlign: "center" }}>Contact</Typography>
              </MenuItem>
              <MenuItem key="sign-in" href="/sign-in">
                <Typography sx={{ textAlign: "center" }}>Sign In</Typography>
              </MenuItem>
            </Menu>
          </Box>
          <Box
            flexGrow={1}
            sx={{
              display: { xs: "none", md: "flex" },
            }}
          >
            <Box width="100%" flexShrink={1} />
            <Box
              width="fit"
              display="flex"
              flexDirection="row"
              alignItems="center"
              flexGrow={1}
            >
              <Button
                key={"create"}
                href="create"
                startIcon={<AddCircleOutlineIcon color="primary" />}
                sx={{
                  my: 2,
                  color: "white",
                  display: "flex",
                }}
              >
                <Typography color="primary" textTransform="none" noWrap>
                  Create
                </Typography>
              </Button>
              <Button
                key={"explore"}
                href="explore"
                sx={{ my: 2, color: "white", display: "block" }}
              >
                <Typography color="black" textTransform="none" noWrap>
                  Explore
                </Typography>
              </Button>
              <Button
                key={"pricing"}
                href="pricing"
                sx={{ my: 2, color: "white", display: "block" }}
              >
                <Typography color="black" textTransform="none" noWrap>
                  Pricing
                </Typography>
              </Button>
              <Button
                key={"about"}
                href="about"
                sx={{ my: 2, color: "white", display: "block" }}
              >
                <Typography color="black" textTransform="none" noWrap>
                  About Us
                </Typography>
              </Button>
              <Button
                key={"contact"}
                href="contact"
                sx={{ my: 2, color: "white", display: "block" }}
              >
                <Typography color="black" textTransform="none" noWrap>
                  Contact
                </Typography>
              </Button>
              <Button
                key={"sign-in"}
                href="sign-in"
                sx={{
                  my: 2,
                  ml: 1,
                  color: "white",
                  display: "flex",
                  border: "solid",
                  borderColor: "#fb7185",
                  borderWidth: 1,
                }}
              >
                <Typography color="#fb7185" textTransform="none" noWrap>
                  Sign In
                </Typography>
              </Button>
            </Box>
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  );
}

export default Header;
