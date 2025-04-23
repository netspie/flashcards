import { Box, Button, Stack, Typography } from "@mui/material";
import EmailNewsletter from "../components/EmailNewsletter";
import AppleIcon from "@mui/icons-material/Apple";
import GoogleIcon from "@mui/icons-material/Google";

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
        sx={{ paddingX: { xs: "24px", md: "128px" } }}
        gap={6}
      >
        <Stack
          sx={{ flexDirection: { xs: "column", xl: "row" } }}
          alignItems="center"
          justifyContent="center"
          gap={10}
        >
          <Stack sx={{ width: { xs: "100%", xl: "30%" } }} gap={2}>
            <Typography
              variant="h4"
              color="secondary"
              sx={{ textAlign: { xs: "center", xl: "left" } }}
            >
              All classes, all exams, one app.
            </Typography>
            <Typography
              textAlign="center"
              sx={{ textAlign: { xs: "center", xl: "left" } }}
            >
              Make your own flashcards or explore sets from teachers, students,
              and pros. Study anytime, anywhere — all for free.
            </Typography>
            <Stack
              flexDirection="row"
              marginTop="18px"
              gap={2}
              sx={{ justifyContent: { xs: "center", xl: "left" } }}
            >
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
          <Box sx={{ width: { xs: "fit", xl: "30%" } }}>
            <img src="/images/home-img-1.jpg" alt="example" width="600" />
          </Box>
        </Stack>
      </Stack>
      <Stack
        alignItems="center"
        justifyContent="center"
        marginTop="64px"
        paddingY="64px"
        sx={{
          paddingX: { xs: "24px", md: "128px" },
        }}
        gap={6}
      >
        <Stack
          sx={{ flexDirection: { xs: "column-reverse", xl: "row" } }}
          alignItems="center"
          justifyContent="center"
          gap={10}
        >
          <Box sx={{ width: { xs: "fit", xl: "30%" } }}>
            <img src="/images/home-img-2.jpg" alt="example" width="600" />
          </Box>
          <Stack sx={{ width: { xs: "100%", xl: "30%" } }} gap={2}>
            <Typography
              variant="h4"
              color="primary"
              sx={{ textAlign: { xs: "center", xl: "left" } }}
            >
              Turn class content into study material instantly.
            </Typography>
            <Typography
              textAlign="center"
              sx={{ textAlign: { xs: "center", xl: "left" } }}
            >
              Convert your slides, videos, and notes into flashcards, practice
              tests, and study guides in seconds.
            </Typography>
            <Stack
              flexDirection="row"
              marginTop="18px"
              gap={2}
              sx={{ justifyContent: { xs: "center", xl: "left" } }}
            >
              <Button href="/" variant="contained" style={{ width: 128 }}>
                Try It Out
              </Button>
            </Stack>
          </Stack>
        </Stack>
      </Stack>
      <Stack
        alignItems="center"
        justifyContent="center"
        marginTop="64px"
        paddingY="64px"
        sx={{ paddingX: { xs: "24px", md: "128px" } }}
        gap={6}
      >
        <Stack
          sx={{ flexDirection: { xs: "column", xl: "row" } }}
          alignItems="center"
          justifyContent="center"
          gap={10}
        >
          <Stack sx={{ width: { xs: "100%", xl: "30%" } }} gap={2}>
            <Typography
              variant="h4"
              color="secondary"
              sx={{ textAlign: { xs: "center", xl: "left" } }}
            >
              Prep for any subject, any time.
            </Typography>
            <Typography
              textAlign="center"
              sx={{ textAlign: { xs: "center", xl: "left" } }}
            >
              Learn faster with tailored practice tests and study sessions. 98%
              of students say Quizlet boosted their understanding.
            </Typography>
            <Stack
              flexDirection="row"
              marginTop="18px"
              gap={2}
              sx={{ justifyContent: { xs: "center", xl: "left" } }}
            >
              <Button
                href="/"
                variant="contained"
                style={{ width: 128, color: "white" }}
                color="secondary"
              >
                Get Started
              </Button>
            </Stack>
          </Stack>
          <Box sx={{ width: { xs: "fit", xl: "30%" } }}>
            <img src="/images/home-img-3.jpg" alt="example" width="600" />
          </Box>
        </Stack>
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
          <Typography variant="h4" color="primary" textAlign="center">
            Master anything with personalized practice.
          </Typography>
          <Typography textAlign="center" my={3}>
            Memorize anything with personalized practice tests. 98% of students
            see improved understanding.
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
    </Stack>
  );
}

export default Home;
