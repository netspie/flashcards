import { Button, Stack, Typography } from '@mui/material'
import XIcon from "@mui/icons-material/X";
import FacebookIcon from "@mui/icons-material/Facebook";
import InstagramIcon from "@mui/icons-material/Instagram";
import YouTubeIcon from "@mui/icons-material/YouTube";

function Footer() {
  return (
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
  )
}

export default Footer