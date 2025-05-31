import { Pagination, Stack, Typography } from "@mui/material";
import { LineChart } from "@mui/x-charts";
import { BarChart } from "@mui/x-charts/BarChart";

function Dashboard() {
  return (
    <Stack alignItems="center" paddingX="15px" paddingBottom={8} gap={12}>
      <Typography variant="h3" color="secondary">
        Dashboard
      </Typography>
      <Stack alignItems="center" gap={4}>
        <Typography variant="h5" color="primary">
          Recent Collections
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
          <RecentCollection name="Hiszpański" cardCount={25} />
          <RecentCollection name="Biologia" cardCount={42} />
          <RecentCollection name="Fizyka" cardCount={30} />
          <RecentCollection name="Historia" cardCount={18} />
          <RecentCollection name="Chemia" cardCount={50} />
        </Stack>
      </Stack>
      <Stack alignItems="center" gap={4}>
        <Typography variant="h5" color="primary">
          Progress
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
          <Stack>
            <Typography fontWeight="bold" textAlign="center">
              Rehearsals Daily
            </Typography>
            <BarChart
              xAxis={[
                {
                  data: [
                    "Matematyka",
                    "Fizyka",
                    "Historia",
                    "Angielski",
                    "Biologia",
                  ],
                },
              ]}
              series={[
                { data: [42, 31, 58, 24, 36] },
                { data: [47, 29, 61, 20, 34] },
                { data: [39, 35, 55, 27, 40] },
                { data: [44, 32, 60, 23, 37] },
                { data: [41, 30, 57, 25, 38] },
              ]}
              width={500}
              height={300}
            />
          </Stack>
          <Stack>
            <Typography fontWeight="bold" textAlign="center">
              Time Spent Studying
            </Typography>
            <LineChart
              xAxis={[{ data: [1, 2, 3, 5, 8, 10] }]}
              series={[
                {
                  data: [2, 5.5, 2, 8.5, 1.5, 5],
                },
              ]}
              width={500}
              height={300}
            />
          </Stack>
        </Stack>
      </Stack>
      <Stack alignItems="center" gap={4}>
        <Typography variant="h5" color="primary">
          Your Collections
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
            name="World War II"
            cardCount={18}
            desc="Important events, leaders, and battles of WWII."
            starCount={4}
          />

          <Tile
            name="Human Anatomy"
            cardCount={25}
            desc="Major organs, systems, and their functions."
            starCount={3}
          />

          <Tile
            name="Basic French"
            cardCount={12}
            desc="Common phrases and vocabulary for beginners."
            starCount={5}
          />

          <Tile
            name="Programming in Python"
            cardCount={30}
            desc="Fundamentals of Python programming language."
            starCount={4}
          />

          <Tile
            name="Art History"
            cardCount={9}
            desc="Movements and influential artists from different eras."
            starCount={2}
          />
        </Stack>
        <Pagination count={10} color="primary" />
      </Stack>
      <Stack alignItems="center" gap={4}>
        <Typography variant="h5" color="primary">
          Favourites
        </Typography>
        <Stack
          display="flex"
          flexWrap="wrap"
          alignItems="center"
          justifyContent="center"
          gap="24px"
          width="100%"
        >
          <Tile
            name="Quantum Physics"
            cardCount={15}
            desc="Core principles of quantum mechanics."
            starCount={3}
            class="w-full"
          />

          <Tile
            name="Ancient Civilizations"
            cardCount={20}
            desc="Facts about Mesopotamia, Egypt, and Greece."
            starCount={4}
          />

          <Tile
            name="Environmental Science"
            cardCount={10}
            desc="Key concepts around ecosystems and sustainability."
            starCount={2}
          />

          <Tile
            name="Modern Literature"
            cardCount={14}
            desc="Themes and authors of 20th century fiction."
            starCount={5}
          />

          <Tile
            name="Music Theory Basics"
            cardCount={8}
            desc="Scales, chords, and notation essentials."
            starCount={3}
          />
        </Stack>
        <Pagination count={10} color="primary" />
      </Stack>
    </Stack>
  );
}

type TileProps = {
  name: string;
  desc: string;
  cardCount: number;
  starCount: number;
  class?: string
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
      className={props.class}
      sx={{ width: { xs: "100%", md: "500px" } }}
    >
      <Stack flexDirection="row">
        <Stack width="100%">
          <Typography variant="h6" color="secondary">
            {props.name}
          </Typography>
          <Typography color="white">{props.desc}</Typography>
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

type RecentCollectionProps = {
  name: string;
  cardCount: number;
};

function RecentCollection(props: RecentCollectionProps) {
  return (
    <Stack
      style={{
        borderRadius: "16px",
        padding: "32px",
        background: "#fb7185",
        cursor: "pointer",
      }}
      className="relative"
      width="200px"
      height="200px"
      alignItems="center"
      justifyContent="center"
    >
      <Typography variant="h6" color="primary">
        {props.name}
      </Typography>
      <Typography color="white">
        <span className="whitespace-nowrap">{props.cardCount} Cards</span>
      </Typography>
    </Stack>
  );
}

export default Dashboard;
