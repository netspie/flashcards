import { Box, Button, Stack, Typography } from "@mui/material";
import EmailNewsletter from "./EmailNewsletter";
import AppleIcon from "@mui/icons-material/Apple";
import GoogleIcon from "@mui/icons-material/Google";

import XIcon from "@mui/icons-material/X";
import FacebookIcon from "@mui/icons-material/Facebook";
import InstagramIcon from "@mui/icons-material/Instagram";
import YouTubeIcon from "@mui/icons-material/YouTube";

function Home() {
  return (
    <Stack padding={0}>
      <Stack alignItems="center" paddingTop="75px" paddingX="15px">
        <Stack
          display="flex"
          flexDirection="column"
          alignItems="center"
          gap="24px"
        >
          <Stack alignItems="center" gap="8px">
            <Typography variant="h3" color="primary" textAlign="center">
              The Best Flashcards
            </Typography>
            <Typography variant="h4" color="secondary" textAlign="center">
              In The Whole Universe
            </Typography>
          </Stack>
          <Typography textAlign="center">
            Learn anything, anytime with flashcards! Boost your memory, track
            your progress, and make studying simple and fun. Start now!
          </Typography>
          <Typography
            textAlign="center"
            textTransform="uppercase"
            color="#aaaaaa"
          >
            A platform empowering learners to stay organized, motivated, and
            successful.
          </Typography>
          <Stack flexDirection="row" gap={2}>
            <Button
              variant="contained"
              color="secondary"
              style={{ color: "white" }}
            >
              Create
            </Button>
            <Button variant="contained" color="primary">
              Donate
            </Button>
          </Stack>
        </Stack>
        <EmailNewsletter style={{ marginTop: "48px" }} />
      </Stack>
      <Stack
        alignItems="center"
        justifyContent="center"
        marginTop="64px"
        paddingY="64px"
        paddingX="128px"
        gap={6}
        style={{ background: "#fafafa" }}
      >
        <Stack alignItems="center">
          <Typography variant="h6" color="primary" textAlign="center">
            Every subject in the ultimate app
          </Typography>
          <Typography textAlign="center">
            Create your own flashcards or find sets made by teachers, students,
            and experts. Study them anytime, anywhere with our free app.
          </Typography>
          <Stack flexDirection="row" marginTop="18px" gap={2}>
            <Button href="/" variant="contained" style={{ width: 128 }}>
              <GoogleIcon />
            </Button>
            <Button
              href="/"
              color="secondary"
              variant="contained"
              style={{ width: 128, color: "white" }}
            >
              <AppleIcon />
            </Button>
          </Stack>
        </Stack>
        <Box>
          <img src="/images/home-img-1.jpg" alt="example" width="600" />
        </Box>
      </Stack>
      <Stack
        padding={4}
        position="relative"
        flexDirection="row"
        alignItems="center"
        justifyContent="center"
      >
        <Typography
          sx={{ position: "absolute", left: 32, display: { xs: "none", md: "flex" } }}
        >
          © 2025 Flashcards, Inc.
        </Typography>
        <Stack flexDirection="row" justifyContent="center">
          <Button href="/">
            <XIcon />
          </Button>
          <Button href="/">
            <FacebookIcon />
          </Button>
          <Button href="/">
            <InstagramIcon />
          </Button>
          <Button href="/">
            <YouTubeIcon />
          </Button>
        </Stack>
      </Stack>
    </Stack>
  );
}

export default Home;
