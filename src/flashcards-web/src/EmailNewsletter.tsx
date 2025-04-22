import { Button, Stack, TextField, Typography } from "@mui/material";

type EmailNewsletterProps = {
  style?: React.CSSProperties;
};

function EmailNewsletter(props: EmailNewsletterProps) {
  return (
    <Stack style={{ borderRadius: "16px", padding: "32px", background: "#000066", ...props.style }} alignItems="center" gap="8px">
      <Typography variant="h6" color="secondary">
        Join Our Email List
      </Typography>
      <Typography color="white" textAlign="center">Get notified about the platform premiere!</Typography>
      <TextField label="Name" fullWidth variant="filled" required style={{ background: "white" }} />
      <TextField label="Email" fullWidth variant="filled" required style={{ background: "white" }} />
      <Button variant="contained" fullWidth color="secondary" style={{ color: "white" }}>
        Join
      </Button>
    </Stack>
  );
}

export default EmailNewsletter;
