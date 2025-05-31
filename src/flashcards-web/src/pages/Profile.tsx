import { Avatar, Button, Stack, TextField, Typography } from "@mui/material";

function Profile() {
  return (
    <Stack alignItems="center" paddingX="15px" gap={12} paddingY={12}>
      <Typography variant="h3" color="secondary">
        Profile
      </Typography>
      <Stack alignItems="center" gap={4}>
        <Avatar
          src="/broken-image.jpg"
          style={{ width: "200px", height: "200px" }}
        />
        <Stack gap={1} alignItems="center">
          <Typography variant="h5">John Kowalsky</Typography>
          <Typography>john@kowalsky.com</Typography>
        </Stack>
        <Button variant="contained" color="primary">
          Edit
        </Button>
      </Stack>
      <Stack>
        <TextField
          id="outlined-multiline-static"
          label="Description"
          multiline
          rows={4}
          defaultValue=" "
          sx={{ width: { xs: "100%", md: "500px" } }}
        />
      </Stack>
    </Stack>
  );
}

export default Profile;
