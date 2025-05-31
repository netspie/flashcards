import { Search, Star, ThumbDown, ThumbUp } from "@mui/icons-material";
import {
  Avatar,
  IconButton,
  InputBase,
  Pagination,
  Paper,
  Stack,
  Typography,
} from "@mui/material";

function Teachers() {
  return (
    <Stack alignItems="center" paddingX="15px" paddingY={12} gap={4}>
      <Typography variant="h3" color="secondary">
        Teachers
      </Typography>
      <Paper
        component="form"
        sx={{ p: "2px 4px", display: "flex", alignItems: "center", width: 400 }}
      >
        <InputBase
          sx={{ ml: 1, flex: 1 }}
          placeholder="Search Teachers"
          inputProps={{ "aria-label": "search collections" }}
        />
        <IconButton type="button" sx={{ p: "10px" }} aria-label="search">
          <Search color="secondary" />
        </IconButton>
      </Paper>
      <Stack
        display="flex"
        flexWrap="wrap"
        alignItems="center"
        justifyContent="center"
        gap="24px"
        width="100%"
        sx={{ flexDirection: { xs: "column", md: "row" } }}
      >
        <Tile
          name="John Smith"
          desc="Passionate educator with 10+ years in STEM, helping students master complex topics through visual learning and interactive flashcards."
          subjects={["Math", "Biology", "Astrophysics"]}
        />

        <Tile
          name="Emily Zhao"
          desc="Language lover and certified ESL instructor focused on building confidence in English through immersive, real-world practice."
          subjects={["English", "TOEFL", "IELTS"]}
        />

        <Tile
          name="Carlos Mendez"
          desc="High school chemistry teacher known for turning abstract concepts into fun, memorable learning experiences using gamified flashcards."
          subjects={["Chemistry", "Physics", "General Science"]}
        />

        <Tile
          name="Aisha Farouk"
          desc="History enthusiast bringing global cultures to life through stories, maps, and timeline-based study techniques."
          subjects={["World History", "Sociology", "Civics"]}
        />

        <Tile
          name="Noah Kim"
          desc="SAT Math coach with a knack for shortcuts, logic tricks, and deep understanding of test psychology."
          subjects={["SAT Prep", "Algebra", "Geometry"]}
        />

        <Tile
          name="Sofia Romano"
          desc="Native Italian speaker and polyglot helping students fall in love with languages through daily practice and themed flashcard decks."
          subjects={["Italian", "Spanish", "French"]}
        />

        <Tile
          name="Liam Johnson"
          desc="Former software engineer turned CS teacher who makes coding fun and accessible for all ages—no jargon, just results."
          subjects={["Computer Science", "JavaScript", "Python"]}
        />

        <Tile
          name="Dr. Anika Patel"
          desc="University lecturer focused on building foundational understanding in biology and preparing students for pre-med success."
          subjects={["Biology", "Anatomy", "Biochemistry"]}
        />
      </Stack>
      <Pagination count={10} color="primary" />
    </Stack>
  );
}

type TileProps = {
  name: string;
  desc: string;
  subjects: string[];
};

function Tile(props: TileProps) {
  return (
    <Stack
      style={{
        borderRadius: "16px",
        padding: "32px",
        background: "#000066",
        cursor: "pointer",
      }}
      className="relative"
      sx={{ width: { xs: "100%", md: "700px" } }}
    >
      <Stack flexDirection="row" gap={4}>
        <Avatar
          src="/broken-image.jpg"
          style={{ width: "100px", height: "100px" }}
        />
        <Stack width="100%">
          <Typography variant="h6" color="secondary">
            {props.name}
          </Typography>
          <Typography color="white">{props.desc}</Typography>
          <Stack flexDirection="row" marginTop={2}>
            {props.subjects.map((subject, i) => (
              <Typography color="grey">
                {subject} {i != props.subjects.length - 1 && ","}
              </Typography>
            ))}
          </Stack>
          <Stack flexDirection="row" marginTop={2} gap={2}>
            <Stack flexDirection="row" gap={1}>
              <ThumbUp color="secondary" />
              <Typography color="white">3254</Typography>
            </Stack>
            <Stack flexDirection="row" gap={1}>
              <ThumbDown style={{ color: "pink" }} />
              <Typography color="white">64</Typography>
            </Stack>
          </Stack>
        </Stack>
      </Stack>
    </Stack>
  );
}

export default Teachers;
