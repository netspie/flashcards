import { Button, Stack, Typography } from "@mui/material";

function Pricing() {
  return (
    <Stack alignItems="center" paddingX="15px" gap={8}>
      <Typography variant="h3" color="secondary">
        PRICING
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
        <PricingItem
          name="Free"
          price={0}
          period="Month"
          perks={[
            "Create up to 5 decks",
            "Basic study mode",
            "Access public decks",
            "Limited search functionality",
          ]}
        />

        <PricingItem
          name="Bronze"
          price={19.99}
          period="Month"
          perks={[
            "Create up to 5 decks",
            "Basic study mode",
            "Access public decks",
            "Limited search functionality",
            "Unlimited deck creation",
            "Advanced study modes (learn/test)",
            "Offline access",
            "Deck sharing with friends",
          ]}
        />

        <PricingItem
          name="Silver"
          price={24.99}
          period="Month"
          perks={[
            "Create up to 5 decks",
            "Basic study mode",
            "Access public decks",
            "Limited search functionality",
            "Unlimited deck creation",
            "Advanced study modes (learn/test)",
            "Offline access",
            "Deck sharing with friends",
            "Progress tracking & analytics",
            "Custom themes for decks",
            "Ad-free experience",
          ]}
        />

        <PricingItem
          name="Gold"
          price={29.99}
          period="Month"
          perks={[
            "Create up to 5 decks",
            "Basic study mode",
            "Access public decks",
            "Limited search functionality",
            "Unlimited deck creation",
            "Advanced study modes (learn/test)",
            "Offline access",
            "Deck sharing with friends",
            "Progress tracking & analytics",
            "Custom themes for decks",
            "Ad-free experience",
            "AI-powered study recommendations",
            "Priority customer support",
          ]}
        />
      </Stack>
    </Stack>
  );
}

type PricingItemProps = {
  name: string;
  price: number;
  period: "Month" | "3 Months" | "6 Months" | "1 Year";
  perks: string[];
};

function PricingItem(props: PricingItemProps) {
  return (
    <Stack
      style={{
        borderRadius: "16px",
        padding: "32px",
        background: "#000066",
        flexDirection: "column",
      }}
      sx={{
        width: { xs: "100%", md: "300px" },
        height: { md: "600px" },
      }}
    >
      <Stack height="100%">
        <Typography variant="h6" color="secondary" align="center">
          {props.name}
        </Typography>
        <Typography color="gold" align="center" marginBottom={4}>
          {props.price} USD / {props.period}
        </Typography>
        <Stack>
          {props.perks.map((perk) => (
            <Typography color="white">
              - {perk}
            </Typography>
          ))}
        </Stack>
      </Stack>
      <Button variant="contained" color="secondary">
        <Typography color="white">Subscribe</Typography>
      </Button>
    </Stack>
  );
}

export default Pricing;
