import { Button, Stack, TextField, Typography } from "@mui/material";

function Create() {
  return (
    <Stack alignItems="center" paddingX="15px" gap={8}>
      <Typography variant="h3" color="secondary">
        CREATE COLLECTION
      </Typography>
      <Stack
        display="flex"
        flexWrap="wrap"
        alignItems="center"
        justifyContent="center"
        gap="24px"
        width="100%"
        sx={{
          flexDirection: { xs: "column", md: "row" },
          paddingX: { xs: "0", md: "200px", lg: "400px" },
        }}
      >
        <Stack alignItems="end" width="100%">
          <Button
            variant="contained"
            color="secondary"
            style={{ width: "fit-content" }}
          >
            <Typography color="white">Create</Typography>
          </Button>
        </Stack>
        <TextField required id="outlined-required" label="Name" fullWidth defaultValue="Japanese Words" />
        <TextField
          required
          id="outlined-required"
          label="Description"
          fullWidth
        />
      </Stack>
      <Stack
        display="flex"
        flexWrap="wrap"
        alignItems="center"
        justifyContent="center"
        gap="24px"
        width="100%"
        sx={{ flexDirection: { xs: "column", md: "row" } }}
      >
        <Card front="Water" back="水" />
        <Card front="Book" back="本" />
        <Card front="Cat" back="猫" />
        <Card front="Eat" back="食べる" />
        <Card front="Friend" back="友達" />
      </Stack>
      <Button variant="contained" style={{ width: "200px" }}>
        <Typography color="white">Add Card</Typography>
      </Button>
    </Stack>
  );
}

type CardProps = {
  front: string;
  back: string;
};

function Card(props: CardProps) {
  return (
    <Stack
      style={{
        flexDirection: "row",
        cursor: "pointer",
        width: "100%",
        justifyContent: "center",
        gap: 24,
      }}
    >
      <Stack
        style={{
          aspectRatio: 1,
          padding: "32px",
          borderRadius: "16px",
          background: "#000066",
          alignItems: "center",
          justifyContent: "center",
        }}
        sx={{
          width: { xs: "150px", md: "200px" },
          height: { xs: "150px", md: "200px" },
        }}
      >
        <Typography variant="h6" color="white">
          {props.front}
        </Typography>
      </Stack>
      <Stack
        style={{
          aspectRatio: 1,
          padding: "32px",
          borderRadius: "16px",
          background: "#fb7185",
          alignItems: "center",
          justifyContent: "center",
        }}
        sx={{
          width: { xs: "150px", md: "200px" },
          height: { xs: "150px", md: "200px" },
        }}
      >
        <Typography variant="h6" color="white">
          {props.back}
        </Typography>
      </Stack>
    </Stack>
  );
}

export default Create;
