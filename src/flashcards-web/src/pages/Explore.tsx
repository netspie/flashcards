import { Search, Star } from "@mui/icons-material";
import {
  IconButton,
  InputBase,
  Pagination,
  Paper,
  Stack,
  Typography,
} from "@mui/material";

function Explore() {
  return (
    <Stack alignItems="center" paddingX="15px" gap={4}>
      <Typography variant="h3" color="secondary">
        EXPLORE
      </Typography>
      <Paper
        component="form"
        sx={{ p: "2px 4px", display: "flex", alignItems: "center", width: 400 }}
      >
        <InputBase
          sx={{ ml: 1, flex: 1 }}
          placeholder="Search Collections"
          inputProps={{ "aria-label": "search collections" }}
        />
        <IconButton type="button" sx={{ p: "10px" }} aria-label="search">
          <Search color="secondary" />
        </IconButton>
      </Paper>
      <Typography color="primary" textTransform="uppercase">
        List of publicly available collections you can learn from
      </Typography>
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
          name="Capital Cities"
          cardCount={12}
          desc="Learn the capitals of countries around the world."
          starCount={4}
        />
        <Tile
          name="Biology Terms"
          cardCount={8}
          desc="Key terms and definitions from biology."
          starCount={4}
        />
        <Tile
          name="Historical Dates"
          cardCount={15}
          desc="Important events and when they happened."
          starCount={4}
        />
        <Tile
          name="Programming Concepts"
          cardCount={10}
          desc="Core ideas every programmer should know."
          starCount={3}
        />
        <Tile
          name="Japanese Words"
          cardCount={9}
          desc="Common Japanese words with meanings."
          starCount={5}
        />
        <Tile
          name="English Words"
          cardCount={5}
          desc="Useful English vocabulary words."
          starCount={5}
        />
        <Tile
          name="Fun Facts"
          cardCount={2}
          desc="Random and surprising trivia."
          starCount={4}
        />
        <Tile
          name="Math Formulas"
          cardCount={7}
          desc="Essential formulas for algebra and geometry."
          starCount={3}
        />
        <Tile
          name="Space Exploration"
          cardCount={6}
          desc="Key milestones and facts about space missions."
          starCount={2}
        />
      </Stack>
      <Pagination count={10} color="primary" />
    </Stack>
  );
}

type TileProps = {
  name: string;
  desc: string;
  cardCount: number;
  starCount: number;
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
      sx={{ width: { xs: "100%", md: "500px" } }}
    >
      <Stack flexDirection="row">
        <Stack width="100%">
          <Typography variant="h6" color="secondary">
            {props.name}
          </Typography>
          <Typography color="white">{props.desc}</Typography>
          <Stack flexDirection="row" marginTop={2}>
            {Array.from({ length: props.starCount }).map((_, i) => (
              <Star key={i} style={{ color: "gold" }} />
            ))}
          </Stack>
        </Stack>
        <Stack>
          <Typography color="white">
            <span className="whitespace-nowrap">{props.cardCount} cards</span>
          </Typography>
        </Stack>
      </Stack>
    </Stack>
  );
}

export default Explore;
